using System.Net.Mail;
using System.Net;

namespace Administracion_Hotelera_API.Controllers
{
    public class Email
    {
        public string sendEmail(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "julianmiranda1@hotmail.com";
            string displayName = "Julian Miranda";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
                client.Credentials = new NetworkCredential(from, "JuliCaro0624");
                client.EnableSsl = true;


                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }

        public string body(string first_name_pssg, DateTime date_start, DateTime date_end, string type_room, 
            int id_room, float value_room, float tax_room)
        {
            return "<!DOCTYPE html>\r\n<html lang=\"es\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\r\n    <title>Confirmación de Reserva</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            margin: 0;\r\n            padding: 0;\r\n            background-color: #f4f4f4;\r\n        }\r\n        .container {\r\n            max-width: 600px;\r\n            margin: auto;\r\n            padding: 20px;\r\n            background-color: #fff;\r\n            border-radius: 10px;\r\n            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);\r\n        }\r\n        h1 {\r\n            color: #333;\r\n        }\r\n        p {\r\n            color: #666;\r\n        }\r\n        .reservation-details {\r\n            margin-top: 20px;\r\n            padding: 20px;\r\n            background-color: #f9f9f9;\r\n            border-radius: 5px;\r\n        }\r\n        .footer {\r\n            margin-top: 20px;\r\n            text-align: center;\r\n        }\r\n        .footer p {\r\n            color: #999;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <div class=\"container\">\r\n        <h1>¡Reserva Confirmada!</h1>\r\n        <p>Estimado " + first_name_pssg + ",</p>\r\n        <p>Su reserva en nuestro sistema ha sido confirmada. A continuación, encontrará los detalles de su reserva:</p>\r\n        <div class=\"reservation-details\">\r\n            <p><strong>Fecha de Entrada:</strong> " + date_start + "</p>\r\n            <p><strong>Fecha de Salida:</strong> " + date_end + "</p>\r\n            <p><strong>Habitación Reservada:</strong> " + type_room + " - Nro. " + id_room + "</p>\r\n            <p><strong>Precio:</strong> $" + value_room + "</p>\r\n            <p><strong>Impuestos:</strong> " + tax_room + "%</p>\r\n        </div>\r\n        <div class=\"footer\">\r\n            <p>Gracias por elegir nuestro hotel. Esperamos que disfrute de su estancia.</p>\r\n        </div>\r\n    </div>\r\n</body>\r\n</html>\r\n";
        }
    }
}
