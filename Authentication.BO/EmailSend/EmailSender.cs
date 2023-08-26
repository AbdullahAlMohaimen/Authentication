using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using SendGrid.Helpers.Mail;

namespace Authentication.BO
{
	#region Email Sender
	public class EmailSender
	{
		#region Constractor
		public EmailSender()
		{
			_to = "";
			_cc = "";
			_body = "";
			_subject = "";
			_attachments = "";
			_from = "";
			_link = "";
		}
		#endregion

		#region Variable
		DataSet oEmpDetails = null;
		DataRow dRow = null;
		string checkSendMail = string.Empty;
		EmailSender sender = null;
		string sbody = "";
		string mailTitle = string.Empty;
		private SmtpClient client = null;
		private object _mailbody;
		#endregion

		#region Mail Property
		#region From
		private string _from;
		public string From
		{
			get { return _from; }
			set { _from = value; }
		}
		#endregion
		#region To
		private string _to;
		public string To
		{
			get { return _to; }
			set { _to = value; }
		}
		#endregion
		#region CC
		private string _cc;
		public string CC
		{
			get { return _cc; }
			set { _cc = value; }
		}
		#endregion
		#region Subject
		private string _subject;
		public string Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}
		#endregion
		#region Body
		private string _body;
		public string Body
		{
			get { return _body; }
			set { _body = value; }
		}
		#endregion
		#region Attachments
		private string _attachments;
		public string Attachments
		{
			get { return _attachments; }
			set { _attachments = value; }
		}
		#endregion
		#region Link
		private string _link;
		public string Link
		{
			get { return _link; }
			set { _link = value; }
		}
		#endregion
		#endregion

		#region Event
		public event EventHandler client_SendCompleted;
		#endregion

		#region Email Sending Methods
		public void ThreadSendMail(EmailSetting emailSettings)
		{
			Thread myNewThread = new Thread(() => SendMail(emailSettings));
			myNewThread.Start();
		}

		#endregion
		#region Email Sending
		public void SendMail(EmailSetting emailSettings)
		{
			try
			{
				string sServer = emailSettings.EmailServer;
				string userID = emailSettings.UserID;
				string checkSendMail = emailSettings.SendMethod; ;
				string password = emailSettings.Password;
				string PortNumber = emailSettings.PortNumber;
				string CheckSSL = emailSettings.EnableSSL;

				password = Decrypt("Cel.Admin", password);

				_body = _body.Trim(' ').TrimEnd('.', ',').TrimEnd('.', ',') + AddLink(_body);
				_from = _from == "" ? emailSettings.FromAddress : _from;

				if (checkSendMail.ToUpper() == "SMTP")
				{
					MailMessage mailMessage = null;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

					client = new SmtpClient(sServer, PortNumber != string.Empty ? Convert.ToInt32(PortNumber) : 25);
					client.EnableSsl = CheckSSL.ToUpper() == "YES" ? true : false;

					if (sServer.Length > 0)
					{
						client.UseDefaultCredentials = true;
						if (userID != "" && password != "")
						{
							client.UseDefaultCredentials = false;
							client.Credentials = new System.Net.NetworkCredential(userID, password);
						}

						mailMessage = new MailMessage(_from, _to, _subject, _body);
						mailMessage.IsBodyHtml = true;

						if (_cc.Length > 0) { mailMessage.CC.Add(_cc); }
						if (_attachments.Length > 0) { mailMessage.Attachments.Add(new System.Net.Mail.Attachment(_attachments)); }

						ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
						client.Send(mailMessage);
						mailMessage.Dispose();
						client.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(ex.Message);
				Exception innerException = ex.InnerException;
				while (innerException != null)
				{
					sb.Append("--> inner Exception: ");
					sb.Append(innerException.Message);
					innerException = innerException.InnerException;
				}

				throw new MailSenderException(sb.ToString());
			}
		}
		#endregion

		public string Decrypt(string key, string data)
		{
			try
			{
				return new EmailSender().DecryptX(key, data);
			}
			catch (Exception e)
			{
				throw new Exception(e.Message, e);
			}
		}

		public string DecryptX(string key, string data)
		{
			string decryptedData = string.Empty;

			//Taking Lenght, half of Encrypting data  
			int len = data.Length / 2;

			//Making key is big Enough
			while (key.Length < len)
			{
				key += key;
			}
			key = key.Substring(0, len);

			char[] keyChrs = key.ToCharArray();
			char[] textChrs = data.ToCharArray();

			//Decripting data
			for (int i = 0; i < len; i++)
			{
				string textByte = string.Empty;
				for (int j = i * 2; j < (i * 2 + 2); j++)
				{
					textByte += string.Format("{0}", textChrs.GetValue(j));
				}
				char textChr = (char)HexToInt(textByte);
				char keyChr = keyChrs[i];

				decryptedData += (char)((int)(keyChr) ^ (int)(textChr));
			}

			len = (int)decryptedData.ToCharArray()[0];
			decryptedData = decryptedData.Substring(1, len);

			return decryptedData;
		}

		protected int HexToInt(string hexData)
		{
			return Convert.ToInt32(hexData, 16);
		}

		#region ADD CC
		public void AddCC(string cc)
		{
			if (IsValidEmail(cc))
			{
				if (_cc == "")
					_cc += cc;
				else
					_cc += cc + ";";
			}
		}
		#endregion

		#region ADD To
		public void AddTo(string to)
		{
			if (IsValidEmail(to))
			{
				if (_to == "")
					_to += to;
				else
					_to += to + ";";
			}
		}
		#endregion

		#region ADD Attachment
		public void AddAttachment(string attachment)
		{
			if (_attachments == "")
				_attachments += attachment;
			else
				_attachments += attachment + ";";
		}
		#endregion

		#region ADD Link
		public string AddLink()
		{
			if (_link.Length > 0)
			{
				return (". Please click on this " + _link.ToString() + " " + " to take action in Luminous self-service (if require)." + "<br/><br/>This is a system generated mail, Please do not reply.");
			}
			else
			{
				return "<br/><br/>This is a system generated mail, Please do not reply.";
			}
		}
		#endregion

		#region ADD Link (Parameter)
		public string AddLink(string sbody)
		{
			if (_link.Length > 0)
			{
				if (sbody.Contains("recognition") && sbody.Contains("approved"))
				{
					return ("To see the details, please click on this " + _link.ToString() + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("recognition"))
				{
					return ("To approve the nomination, please click on this " + _link.ToString() + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("reverted"))
				{
					return (". Please click on this " + _link.ToString() + " " + " to access." + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("Declined"))
				{
					return (". Please click on this " + _link.ToString() + " " + " to access." + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("Recruitment"))
				{
					if ((sbody.Contains("Department") && sbody.Contains("Head")) || sbody.Contains("approved by HR"))
					{
						return (". To accept the request, please click on this " + _link.ToString() + " to access. <br/><br/>This is a system generated mail, Please do not reply.");
					}
					return (". Please click on this " + _link.ToString() + " to access. <br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("approved"))
				{
					return (". Please click on this " + _link.ToString() + " " + " to access." + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("accepted"))
				{
					return (". Please click on this link for access: " + _link.ToString() + " " + " ." + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else if (sbody.Contains("Attendance"))
				{
					return (_link.ToString() + "<br/><br/>This is a system generated mail, Please do not reply.");
				}
				else
				{
					return (". To accept the reliever request during the mentioned period, please click on this " + _link.ToString() + "." + "<br/><br/>This is a system generated mail, Please do not reply.");
				}}
			else
			{
				return "<br/><br/>This is a system generated mail, Please do not reply.";
			}
		}
		#endregion

		#region Email Validation
		public static bool IsValidEmail(string inputEmail)
		{
			int n1 = inputEmail.IndexOf("@");
			int n2 = inputEmail.IndexOf(".");
			int n4 = inputEmail.LastIndexOf(".");
			int n3 = inputEmail.IndexOf(" ");
			if (n3 > 0)
				return false;
			if (n2 < n4)
				n2 = n4;
			if (n1 < n2)
				return true;
			else
				return false;
		}
		#endregion

		#region Validate Server Certificate
		public bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			// replace with proper validation
			if (sslPolicyErrors == SslPolicyErrors.None)
				return true;
			else
				return false;
		}
		#endregion

		#region ADD CC
		public void SendPasswordMail(EmailSetting emailSettings)
		{
			try
			{
				string sServer = emailSettings.EmailServer;
				string userID = emailSettings.UserID;
				string checkSendMail = emailSettings.SendMethod; ;
				string password = emailSettings.Password;
				string PortNumber = emailSettings.PortNumber;
				string CheckSSL = emailSettings.EnableSSL;

				_body = _body.Trim(' ').TrimEnd('.', ',').TrimEnd('.', ',') + AddLink(_body);
				_from = _from == "" ? emailSettings.FromAddress : _from;

				if (checkSendMail.ToUpper() == "SMTP")
				{
					MailMessage mailMessage = null;
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);

					client = new SmtpClient(sServer, PortNumber != string.Empty ? Convert.ToInt32(PortNumber) : 25);
					client.EnableSsl = CheckSSL.ToUpper() == "YES" ? true : false;

					if (sServer.Length > 0)
					{
						client.UseDefaultCredentials = true;
						if (userID != "" && password != "")
						{
							client.UseDefaultCredentials = false;
							client.Credentials = new System.Net.NetworkCredential(userID, password);
						}

						mailMessage = new MailMessage(_from, _to, _subject, _body);
						mailMessage.IsBodyHtml = true;

						//mailMessage.Attachments.Add(att);
						//if (_cc.Length > 0) { mailMessage.CC.Add(_cc); }
						//if (_attachments.Length > 0) { mailMessage.Attachments.Add(new System.Net.Mail.Attachment(_attachments)); }

						ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
						client.Send(mailMessage);
						mailMessage.Dispose();
						client.Dispose();
					}
				}
			}
			catch (Exception ex)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(ex.Message);
				Exception innerException = ex.InnerException;
				while (innerException != null)
				{
					sb.Append("--> inner Exception: ");
					sb.Append(innerException.Message);
					innerException = innerException.InnerException;
				}

				throw new MailSenderException(sb.ToString());
			}
		}
		#endregion
	}
	#endregion


	#region Mail Sender Exception
	public class MailSenderException : Exception
	{
		public MailSenderException(string message)
			: base("Failed to Send Mail due to:" + message)
		{

		}
		public MailSenderException(string message, Exception innerException)
			: base("Failed to Send Mail due to:" + message, innerException)
		{

		}
	}
	#endregion
}
