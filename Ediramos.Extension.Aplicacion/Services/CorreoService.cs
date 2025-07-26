using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Ediramos.Extension.Aplicacion.Servicios
{
    public class CorreoService
    {
        private readonly string correoRemitente = "ramosesteban682@gmail.com";
        private readonly string claveApp = "gldyopznfsoopxoi";

        public async Task EnviarCorreoGenericoAsync(List<string> correosDestino, string asunto, string cuerpoHtmlPersonalizado)
        {
            if (correosDestino == null || !correosDestino.Any()) return;

            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress("Sistema de Convocatorias", correoRemitente));

            foreach (var correo in correosDestino)
                mensaje.To.Add(MailboxAddress.Parse(correo));

            mensaje.Subject = asunto;

            string cuerpoFinal = GenerarPlantillaHtml(cuerpoHtmlPersonalizado);

            mensaje.Body = new TextPart("html") { Text = cuerpoFinal };

            using var cliente = new MailKit.Net.Smtp.SmtpClient();
            await cliente.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await cliente.AuthenticateAsync(correoRemitente, claveApp);
            await cliente.SendAsync(mensaje);
            await cliente.DisconnectAsync(true);
        }

        private string GenerarPlantillaHtml(string contenidoHtml)
        {
            var html = @"
            <!DOCTYPE html>
            <html>
            <head>
              <style>
                body { font-family: Arial, sans-serif; color: #000000; }
                .firma-container {
                    margin-top: 30px;
                    padding: 20px 0;
                    border-top: 3px solid #008000;
                    border-bottom: 3px solid #008000;
                    display: flex;
                    justify-content: space-between;
                    align-items: center;
                    gap: 20px;
                }
                .firma-columna { flex: 1; }
                .firma-columna img { width: 100px; height: 100px; border: 1px solid #ccc; object-fit: cover; }
                .firma-nombre { font-weight: bold; font-size: 14px; }
                .firma-cargo { font-size: 13px; font-weight: bold; }
                .firma-info { font-size: 13px; color: #333; }
                .pie {
                    color: #666;
                    font-size: 11px;
                    margin-top: 20px;
                    border-top: 1px solid #ccc;
                    padding-top: 10px;
                }
                .rojo { color: #b30000; font-style: italic; }
              </style>
            </head>
            <body>
              <p>Estimado/a,</p>
              {{contenido}}

              <div class='firma-container'>
                <div class='firma-columna'></div>
                <div class='firma-columna'>
                  <p class='firma-nombre'>NOMBRE COORDINADOR</p>
                  <p class='firma-cargo'>Coordinador</p>
                  <p class='firma-info'>Extensión y Proyección Social</p>
                </div>
                <div class='firma-columna'>
                  <p><a href='mailto:fingenieria@uniamazonia.edu.co'>departamentoextension@uniamazonia.edu.co</a></p>
                  <p><a href='https://www.uniamazonia.edu.co'>www.uniamazonia.edu.co</a></p>
                  <p>Calle 17 Diagonal 17 Carrera 3F, Barrio Porvenir</p>
                </div>
              </div>

              <div class='pie'>
                <p class='rojo'>""Gestión e Investigación para el Desarrollo de la Amazonía""</p>
                <p>No imprima este e-mail a menos que sea absolutamente necesario. 'Protejamos el medio ambiente'</p>
              </div>
            </body>
            </html>";

            return html.Replace("{{contenido}}", contenidoHtml);
        }
    }
}
