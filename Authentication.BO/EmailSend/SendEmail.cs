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
using System.Data.SqlClient;
using Authentication.BO;
using iTextSharp.text.pdf.parser;
using System.Globalization;
using Authentication.BO.Employee;

namespace Authentication.BO.SendEmail
{
	[Serializable]
	public class SendEmail
	{
		#region Constractor
		public SendEmail()
		{
			_from = "authenticationmh@gmail.com";
			_to = "";
			_body = "";
			_subject = "";
			_fromEmailPassword = "qdxflaqoohshyocn";
		}
		#endregion

		#region SendMail Property

		#region FROM: (string) - Sender Email
		private string _from;
		public string From
		{
			get { return _from; }
			set { _from = value; }
		}
		#endregion

		#region Sender Email Password
		private string _fromEmailPassword;
		public string FromEmailPassword
		{
			get { return _fromEmailPassword; }
			set { _fromEmailPassword = value; }
		}
		#endregion

		#region TO (string) - Reciver Email
		private string _to;
		public string To
		{
			get { return _to; }
			set { _to = value; }
		}
		#endregion

		#region Email Subject
		private string _subject;
		public string Subject
		{
			get { return _subject; }
			set { _subject = value; }
		}
		#endregion

		#region Email Body
		private string _body;
		public string Body
		{
			get { return _body; }
			set { _body = value; }
		}
		#endregion

		#endregion

		public void SendigEmail(SendEmail sendEmail)
		{
			MailMessage mailSender = new MailMessage();
			mailSender.From = new MailAddress(sendEmail.From);
			mailSender.To.Add(new MailAddress(sendEmail.To));
			mailSender.Subject = sendEmail.Subject;
			mailSender.Body = sendEmail.Body;

			mailSender.IsBodyHtml = true;

			var client = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new System.Net.NetworkCredential(sendEmail.From, sendEmail.FromEmailPassword),
				EnableSsl = true,
			};
			client.Send(mailSender);
		}
	}
}