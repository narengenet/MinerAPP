using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.DependencyInjection;
using MimeKit;
using MimeKit.Text;
using MinerAPP.Application.Interfaces;
using MinerAPP.Infrastructure.Repositories;
using MinerAPP.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace MinerAPP.Infrastructure
{
    public static class DependencyContainer
    {
        public static void AddIoCService(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UserRepository>();
            services.AddScoped<IUsersLoginsRepository, UsersLoginsRepository>();
            services.AddScoped<IStaticDictionariesRepository, StaticDictionariesRepository>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();

            services.AddScoped<IUsersServices, UsersServices>();
        }

        public static void SendEmail(string toEmail, string subject, string templatePath, string[] replacedParams = null)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("sina.developer@omanmultimedia.com"));
            //email.To.Add(MailboxAddress.Parse(toEmail));
            //email.Subject = subject;
            //string body = ReadTemplateHtml(templatePath, replacedParams);
            //email.Body = new TextPart(TextFormat.Html) { Text = body };

            //using var smtp = new SmtpClient();
            //smtp.Connect("mail.omanmultimedia.com", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("sina.developer@omanmultimedia.com", "Blueframe95!!");
            //smtp.Send(email);
            //smtp.Disconnect(true);
        }

        public static string ReadTemplateHtml(string templatePath, string[] replacedParams = null)
        {
            string result = "";
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = Environment.CurrentDirectory + "\\wwwroot\\" + templatePath;

            if (File.Exists(resourceName))
            {

                using (var sr = new StreamReader(resourceName))
                {
                    // Read the stream as a string, and write the string to the console.
                    result= sr.ReadToEnd();
                }

                if (replacedParams != null)
                {
                    for (int i = 0; i < replacedParams.Length; i++)
                    {
                        if (result.Contains("@@@" + i.ToString() + "###"))
                        {
                            result=result.Replace("@@@" + i.ToString() + "###", replacedParams[i]);
                        }
                    }
                }
            }

            return result;
        }
    }
}
