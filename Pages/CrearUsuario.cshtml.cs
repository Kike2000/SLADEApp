using CongresoServer.Data;
using CongresoServer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Text;

namespace CongresoServer.Pages
{
    public class CrearUsuarioModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public CrearUsuarioModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<string> OnPostAsync(string role, IdentityUser identityUser, Participante participante)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(identityUser.Email);
                if (user == null) //If user email doesn't exist in user table
                {
                    string randomPassword = "SLADe2710*";
                    var result = await _userManager.CreateAsync(identityUser, randomPassword);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(identityUser, role);

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                        var test = await _userManager.ConfirmEmailAsync(identityUser, code);
                        
                        string servidor = "outlook.office365.com";
                        SmtpClient client = new SmtpClient();
                        client.UseDefaultCredentials = false;
                        client.Credentials = new System.Net.NetworkCredential("congresosladepv@outlook.com", "xxxVcongresoPv202229*", servidor);
                        //client.Credentials = new System.Net.NetworkCredential("sladecongresopv@outlook.com", "Testing123*", servidor);
                        client.Port = 25; // 25 587
                        client.Host = "smtp.office365.com";
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.EnableSsl = true;
                        var tes = "<!DOCTYPE HTML PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional //EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\n<head>\n<!--[if gte mso 9]>\n<xml>\n  <o:OfficeDocumentSettings>\n    <o:AllowPNG/>\n    <o:PixelsPerInch>96</o:PixelsPerInch>\n  </o:OfficeDocumentSettings>\n</xml>\n<![endif]-->\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n  <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n  <meta name=\"x-apple-disable-message-reformatting\">\n  <!--[if !mso]><!--><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\"><!--<![endif]-->\n  <title></title>\n  \n    <style type=\"text/css\">\n      @media only screen and (min-width: 620px) {\n  .u-row {\n    width: 600px !important;\n  }\n  .u-row .u-col {\n    vertical-align: top;\n  }\n\n  .u-row .u-col-100 {\n    width: 600px !important;\n  }\n\n}\n\n@media (max-width: 620px) {\n  .u-row-container {\n    max-width: 100% !important;\n    padding-left: 0px !important;\n    padding-right: 0px !important;\n  }\n  .u-row .u-col {\n    min-width: 320px !important;\n    max-width: 100% !important;\n    display: block !important;\n  }\n  .u-row {\n    width: calc(100% - 40px) !important;\n  }\n  .u-col {\n    width: 100% !important;\n  }\n  .u-col > div {\n    margin: 0 auto;\n  }\n}\nbody {\n  margin: 0;\n  padding: 0;\n}\n\ntable,\ntr,\ntd {\n  vertical-align: top;\n  border-collapse: collapse;\n}\n\np {\n  margin: 0;\n}\n\n.ie-container table,\n.mso-container table {\n  table-layout: fixed;\n}\n\n* {\n  line-height: inherit;\n}\n\na[x-apple-data-detectors=\'true\'] {\n  color: inherit !important;\n  text-decoration: none !important;\n}\n\ntable, td { color: #000000; } #u_body a { color: #0000ee; text-decoration: underline; } @media (max-width: 480px) { #u_content_image_2 .v-container-padding-padding { padding: 0px !important; } #u_content_image_2 .v-src-width { width: auto !important; } #u_content_image_2 .v-src-max-width { max-width: 100% !important; } #u_content_image_3 .v-container-padding-padding { padding: 34px 10px 14px !important; } #u_content_image_3 .v-src-width { width: auto !important; } #u_content_image_3 .v-src-max-width { max-width: 100% !important; } #u_content_text_1 .v-container-padding-padding { padding: 3px 10px 21px !important; } #u_content_text_7 .v-container-padding-padding { padding: 10px 10px 44px 14px !important; } }\n    </style>\n  \n  \n\n<!--[if !mso]><!--><link href=\"https://fonts.googleapis.com/css?family=Montserrat:400,700\" rel=\"stylesheet\" type=\"text/css\"><!--<![endif]-->\n\n</head>\n\n<body class=\"clean-body u_body\" style=\"margin: 0;padding: 0;-webkit-text-size-adjust: 100%;background-color: #ffffff;color: #000000\">\n  <!--[if IE]><div class=\"ie-container\"><![endif]-->\n  <!--[if mso]><div class=\"mso-container\"><![endif]-->\n  <table id=\"u_body\" style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;min-width: 320px;Margin: 0 auto;background-color: #ffffff;width:100%\" cellpadding=\"0\" cellspacing=\"0\">\n  <tbody>\n  <tr style=\"vertical-align: top\">\n    <td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">\n    <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\" style=\"background-color: #ffffff;\"><![endif]-->\n    \n\n<div class=\"u-row-container\" style=\"padding: 0px;background-image: url(\'https://cdn.templates.unlayer.com/assets/1666001657589-back.png\');background-repeat: no-repeat;background-position: center top;background-color: transparent\">\n  <div class=\"u-row\" style=\"Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: #f5b543;\">\n    <div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-image: url(\'https://cdn.templates.unlayer.com/assets/1666001657589-back.png\');background-repeat: no-repeat;background-position: center top;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: #f5b543;\"><![endif]-->\n      \n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\" valign=\"top\"><![endif]-->\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\n  <div style=\"height: 100%;width: 100% !important;\">\n  <!--[if (!mso)&(!IE)]><!--><div style=\"height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;\"><!--<![endif]-->\n  \n<table id=\"u_content_image_2\" style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">\n  <tr>\n    <td style=\"padding-right: 0px;padding-left: 0px;\" align=\"left\">\n      \n      <img align=\"left\" border=\"0\" src=\"https://assets.unlayer.com/projects/109714/1666810495495-curvas_.png\" alt=\"image\" title=\"image\" style=\"outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 100%;max-width: 600px;\" width=\"600\" class=\"v-src-width v-src-max-width\"/>\n      \n    </td>\n  </tr>\n</table>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n<table id=\"u_content_image_3\" style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">\n  <tr>\n    <td style=\"padding-right: 0px;padding-left: 0px;\" align=\"center\">\n      \n      <img align=\"center\" border=\"0\" src=\"https://assets.unlayer.com/projects/109714/1666809542691-logos.png\" alt=\"image\" title=\"image\" style=\"outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: inline-block !important;border: none;height: auto;float: none;width: 100%;max-width: 580px;\" width=\"580\" class=\"v-src-width v-src-max-width\"/>\n      \n    </td>\n  </tr>\n</table>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n<table id=\"u_content_text_1\" style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:11px 80px 31px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <div style=\"line-height: 140%; text-align: center; word-wrap: break-word;\">\n    <p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 20px; line-height: 28px;\"><span style=\"line-height: 28px; font-size: 20px;\"><strong>{Nombre}</strong></span></span></p>\n<p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 22px; line-height: 30.8px;\"><strong><span style=\"line-height: 30.8px; font-size: 22px;\">Bienvenido al Congreso SLADE XXXV</span></strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%;\"><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\"><strong><span style=\"font-size: 14px; line-height: 19.6px;\">El presente es para informarle que se le habilitó en el sistema para que realice su agenda registrando las Mesas o Talleres a los cuales desee asistir.</span></strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: justify;\"><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\"><strong><span style=\"font-size: 14px; line-height: 19.6px;\">La cuenta de acceso es su correo electrónico registrado: <span style=\"color: #306455; font-size: 14px; line-height: 19.6px;\">{correo}</span> y su clave secreta o password es: <span style=\"color: #306455; font-size: 14px; line-height: 19.6px;\">{password}</span></span></strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: justify;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: center;\"><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\"><strong><span style=\"font-size: 14px; line-height: 19.6px;\"><span style=\"font-size: 14px; line-height: 19.6px;\">Para realizar la agenda acceda a: <span style=\"font-size: 16px; line-height: 22.4px;\"><em>https://congresoslade.azurewebsites.net/Login</em></span></span></span></strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: justify;\"><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\"><strong><span style=\"font-size: 14px; line-height: 19.6px;\">Las actividades Magistrales, plenarias, inauguración y ceremonia de clausura están registradas por defecto y no se pueden eliminar.</span></strong></span></p>\n  </div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\n  </div>\n</div>\n<!--[if (mso)|(IE)]></td><![endif]-->\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\n    </div>\n  </div>\n</div>\n\n\n\n<div class=\"u-row-container\" style=\"padding: 0px;background-color: transparent\">\n  <div class=\"u-row\" style=\"Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">\n    <div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\n      \n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"background-color: #f5b543;width: 600px;padding: 2px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\n  <div style=\"background-color: #f5b543;height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\">\n  <!--[if (!mso)&(!IE)]><!--><div style=\"height: 100%; padding: 2px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\"><!--<![endif]-->\n  \n<table style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:13px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <div style=\"line-height: 140%; text-align: left; word-wrap: break-word;\">\n    <p style=\"font-size: 14px; line-height: 140%; text-align: center;\"><strong><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\">El sitio tiene dos apartados: Agenda de Congreso y Mi Agenda</span></strong></p>\n  </div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\n  </div>\n</div>\n<!--[if (mso)|(IE)]></td><![endif]-->\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\n    </div>\n  </div>\n</div>\n\n\n\n<div class=\"u-row-container\" style=\"padding: 0px;background-color: transparent\">\n  <div class=\"u-row\" style=\"Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">\n    <div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\n      \n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"background-color: #f5b543;width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\n  <div style=\"background-color: #f5b543;height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\">\n  <!--[if (!mso)&(!IE)]><!--><div style=\"height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\"><!--<![endif]-->\n  \n<table style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <div style=\"line-height: 140%; text-align: left; word-wrap: break-word;\">\n    <p style=\"font-size: 14px; line-height: 140%; text-align: justify;\"><strong><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\">En la Agenda del Congreso, seleccione la Mesa o Taller a la que desee asistir, dentro de esta página presione registrar; regresar, para ir a la agenda del congreso y seleccionar la siguiente.</span></strong></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%;\"><strong><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\">Realice la actividad anterior para el resto de las actividades. Se puede auxiliar del programa en:</span></strong> <a rel=\"noopener\" href=\"https://www.sladexxxv.com/SLADE_XXXV_PROGRAMA_CONGRESO_V2.pdf\" target=\"_blank\">https://www.sladexxxv.com/SLADE_XXXV_PROGRAMA_CONGRESO_V2.pdf</a></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: justify;\"><strong><span style=\"color: #ffffff; font-size: 14px; line-height: 19.6px;\">Una vez registradas sus Mesas o Talleres a los que asistirá, entrar en Mi Agenda, ir hasta el final, donde se localiza el código QR generado y realizar una captura de pantalla en su dispositivo,  ya que se le solicitará mostrar esta para registrar su asistencia a la entrada de cada uno de los eventos.</span></strong></p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n  </div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\n  </div>\n</div>\n<!--[if (mso)|(IE)]></td><![endif]-->\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\n    </div>\n  </div>\n</div>\n\n\n\n<div class=\"u-row-container\" style=\"padding: 0px;background-color: transparent\">\n  <div class=\"u-row\" style=\"Margin: 0 auto;min-width: 320px;max-width: 600px;overflow-wrap: break-word;word-wrap: break-word;word-break: break-word;background-color: transparent;\">\n    <div style=\"border-collapse: collapse;display: table;width: 100%;height: 100%;background-color: transparent;\">\n      <!--[if (mso)|(IE)]><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"padding: 0px;background-color: transparent;\" align=\"center\"><table cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"width:600px;\"><tr style=\"background-color: transparent;\"><![endif]-->\n      \n<!--[if (mso)|(IE)]><td align=\"center\" width=\"600\" style=\"background-color: #306455;width: 600px;padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\" valign=\"top\"><![endif]-->\n<div class=\"u-col u-col-100\" style=\"max-width: 320px;min-width: 600px;display: table-cell;vertical-align: top;\">\n  <div style=\"background-color: #306455;height: 100%;width: 100% !important;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\">\n  <!--[if (!mso)&(!IE)]><!--><div style=\"height: 100%; padding: 0px;border-top: 0px solid transparent;border-left: 0px solid transparent;border-right: 0px solid transparent;border-bottom: 0px solid transparent;border-radius: 0px;-webkit-border-radius: 0px; -moz-border-radius: 0px;\"><!--<![endif]-->\n  \n<table style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:0px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <table height=\"0px\" align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" style=\"border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;border-top: 4px solid #4fa79f;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\">\n    <tbody>\n      <tr style=\"vertical-align: top\">\n        <td style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top;font-size: 0px;line-height: 0px;mso-line-height-rule: exactly;-ms-text-size-adjust: 100%;-webkit-text-size-adjust: 100%\">\n          <span>&#160;</span>\n        </td>\n      </tr>\n    </tbody>\n  </table>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n<table style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:20px 10px 10px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <div style=\"color: #ffffff; line-height: 140%; text-align: center; word-wrap: break-word;\">\n    <p style=\"font-size: 14px; line-height: 140%;\"><span style=\"font-size: 24px; line-height: 33.6px;\"><strong>¡SALUDOS!</strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%;\">Comité Organizador del Congreso SLADE XXXV</p>\n  </div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n<table style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:10px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n<div align=\"center\">\n  <div style=\"display: table; max-width:125px;\">\n  <!--[if (mso)|(IE)]><table width=\"125\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td style=\"border-collapse:collapse;\" align=\"center\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" style=\"border-collapse:collapse; mso-table-lspace: 0pt;mso-table-rspace: 0pt; width:125px;\"><tr><![endif]-->\n  \n    \n    <!--[if (mso)|(IE)]><td width=\"32\" style=\"width:32px; padding-right: 10px;\" valign=\"top\"><![endif]-->\n    <table align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"32\" height=\"32\" style=\"width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 10px\">\n      <tbody><tr style=\"vertical-align: top\"><td align=\"left\" valign=\"middle\" style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">\n        <a href=\"https://twitter.com/sladeinter\" title=\"Twitter\" target=\"_blank\">\n          <img src=\"https://cdn.tools.unlayer.com/social/icons/circle-white/twitter.png\" alt=\"Twitter\" title=\"Twitter\" width=\"32\" style=\"outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important\">\n        </a>\n      </td></tr>\n    </tbody></table>\n    <!--[if (mso)|(IE)]></td><![endif]-->\n    \n    <!--[if (mso)|(IE)]><td width=\"32\" style=\"width:32px; padding-right: 10px;\" valign=\"top\"><![endif]-->\n    <table align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"32\" height=\"32\" style=\"width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 10px\">\n      <tbody><tr style=\"vertical-align: top\"><td align=\"left\" valign=\"middle\" style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">\n        <a href=\"https://www.youtube.com/channel/UClfdAAZBAN8zj5FSFHlYxqQ\" title=\"YouTube\" target=\"_blank\">\n          <img src=\"https://cdn.tools.unlayer.com/social/icons/circle-white/youtube.png\" alt=\"YouTube\" title=\"YouTube\" width=\"32\" style=\"outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important\">\n        </a>\n      </td></tr>\n    </tbody></table>\n    <!--[if (mso)|(IE)]></td><![endif]-->\n    \n    <!--[if (mso)|(IE)]><td width=\"32\" style=\"width:32px; padding-right: 0px;\" valign=\"top\"><![endif]-->\n    <table align=\"left\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"32\" height=\"32\" style=\"width: 32px !important;height: 32px !important;display: inline-block;border-collapse: collapse;table-layout: fixed;border-spacing: 0;mso-table-lspace: 0pt;mso-table-rspace: 0pt;vertical-align: top;margin-right: 0px\">\n      <tbody><tr style=\"vertical-align: top\"><td align=\"left\" valign=\"middle\" style=\"word-break: break-word;border-collapse: collapse !important;vertical-align: top\">\n        <a href=\"https://www.facebook.com/sladeinternacional/\" title=\"Facebook\" target=\"_blank\">\n          <img src=\"https://cdn.tools.unlayer.com/social/icons/circle-white/facebook.png\" alt=\"Facebook\" title=\"Facebook\" width=\"32\" style=\"outline: none;text-decoration: none;-ms-interpolation-mode: bicubic;clear: both;display: block !important;border: none;height: auto;float: none;max-width: 32px !important\">\n        </a>\n      </td></tr>\n    </tbody></table>\n    <!--[if (mso)|(IE)]></td><![endif]-->\n    \n    \n    <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\n  </div>\n</div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n<table id=\"u_content_text_7\" style=\"font-family:\'Montserrat\',sans-serif;\" role=\"presentation\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\" border=\"0\">\n  <tbody>\n    <tr>\n      <td class=\"v-container-padding-padding\" style=\"overflow-wrap:break-word;word-break:break-word;padding:8px 100px 12px;font-family:\'Montserrat\',sans-serif;\" align=\"left\">\n        \n  <div style=\"color: #ffffff; line-height: 140%; text-align: center; word-wrap: break-word;\">\n    <p style=\"font-size: 14px; line-height: 140%; text-align: center;\"><span style=\"font-size: 20px; line-height: 28px;\"><strong><span style=\"line-height: 28px; font-size: 20px;\">Contacto</span></strong></span></p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: center;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: left;\">Cualquier duda puede escribirnos al siguiente correo:</p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: left;\"><a rel=\"noopener\" href=\"mailto:congresosladepv@outlook.com\" target=\"_blank\">congresosladepv@outlook.com</a><a rel=\"noopener\" href=\"mailto:coordinacion@sladexxxv.com\" target=\"_blank\"></a></p>\n<p style=\"font-size: 14px; line-height: 140%; text-align: left;\">Tel. (+52) 322 226 5600 ext. 219</p>\n<p style=\"font-size: 14px; line-height: 140%;\"> </p>\n<p style=\"font-size: 14px; line-height: 140%;\">© SLADE 2022 • All rights reserved.</p>\n  </div>\n\n      </td>\n    </tr>\n  </tbody>\n</table>\n\n  <!--[if (!mso)&(!IE)]><!--></div><!--<![endif]-->\n  </div>\n</div>\n<!--[if (mso)|(IE)]></td><![endif]-->\n      <!--[if (mso)|(IE)]></tr></table></td></tr></table><![endif]-->\n    </div>\n  </div>\n</div>\n\n\n    <!--[if (mso)|(IE)]></td></tr></table><![endif]-->\n    </td>\n  </tr>\n  </tbody>\n  </table>\n  <!--[if mso]></div><![endif]-->\n  <!--[if IE]></div><![endif]-->\n</body>\n\n</html>";
                        System.Net.Mail.MailMessage mails = new System.Net.Mail.MailMessage
                        {
                            From = new MailAddress("congresosladepv@outlook.com", "Congreso SLADE XXXV"),
                            //From = new MailAddress("sladecongresopv@outlook.com", "Congreso SLADE XXXV"),
                            Subject = "Registro de Agenda SLADE XXXV",
                            IsBodyHtml = true,                            
                        };
                        mails.To.Add("pedro.crodriguez@alumnos.udg.mx");
                        //mails.CC.Add("jluis.lopez@academicos.udg.mx");
                        if (participante != null)
                        {
                            mails.Body = tes.Replace("{Nombre}", participante.Nombre).Replace("{correo}", participante.Email).Replace("{password}", randomPassword);
                            participante.Contraseña = "SLADe2710*";
                            _context.Participante.Add(participante);
                        }
                        else
                        {
                            mails.Body = tes.Replace("{Nombre}", identityUser.Email).Replace("{correo}", identityUser.Email).Replace("{password}", randomPassword);
                        }
                        await _context.SaveChangesAsync();
                        if (participante != null)
                        {
                            var eventos27 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 27 && p.HoraInicio.Value.Hour < 13).ToList();
                            var eventos28 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 28 && p.HoraInicio.Value.Hour < 13).ToList();
                            var eventos29 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 29 && p.HoraInicio.Value.Hour < 13).ToList();
                            foreach (var evento in eventos27)
                            {
                                var Registro = new Model.Registro
                                {
                                    EventoId = evento.Id,
                                    ParticipanteId = participante.Id,
                                    HoraDeRegistro = DateTime.Now.ToUniversalTime()
                                };
                                evento.Cupo = evento.Cupo - 1;
                                _context.Registro.Add(Registro);
                                _context.Evento.Update(evento);
                            }
                            foreach (var evento in eventos28)
                            {
                                var Registro = new Model.Registro
                                {
                                    EventoId = evento.Id,
                                    ParticipanteId = participante.Id,
                                    HoraDeRegistro = DateTime.Now.ToUniversalTime()
                                };
                                evento.Cupo = evento.Cupo - 1;
                                _context.Registro.Add(Registro);
                                _context.Evento.Update(evento);
                            }
                            foreach (var evento in eventos29)
                            {
                                var Registro = new Model.Registro
                                {
                                    EventoId = evento.Id,
                                    ParticipanteId = participante.Id,
                                    HoraDeRegistro = DateTime.Now.ToUniversalTime()
                                };
                                evento.Cupo = evento.Cupo - 1;
                                _context.Registro.Add(Registro);
                                _context.Evento.Update(evento);
                            }
                            await _context.SaveChangesAsync();
                        }
                        try
                        {
                            client.Send(mails);
                        }
                        catch (Exception ex)
                        {
                            return "Usuario agregado pero correo no envíado";
                        }
                        return "Usuario agregado y correo envíado";
                    }
                }
                else
                {
                    return "Usuario no agregado, hubo un error";
                }
                return "Usuario ya existe";

            }
            catch (Exception ex)
            {
                return "Usuario no agregado";
            }
        }
        public class NuevoParticipante
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Email { get; set; }
            public string Procedencia { get; set; }
        }
        //public async Task RegistroParticipantes()
        //{
        //    var todosParticipantes = _context.Participante.ToList();
        //    var participantes = JsonConvert.DeserializeObject<List<NuevoParticipante>>(System.IO.File.ReadAllText("wwwroot/participantes.json"));
        //    var participantesNoRepetidos = participantes.Where(p => p.Email != null && p.Email != "0" && p.Email.Contains("@")).ToList();
        //    var newest = new List<NuevoParticipante>();
        //    foreach (var item in participantesNoRepetidos)
        //    {
        //        if (item.Email.Contains(" "))
        //        {
        //            item.Email = item.Email.Replace(" ", "");
        //        }
        //        if (newest.Any(p => p.Email.Contains(item.Email)))
        //        {

        //        }
        //        else
        //        {
        //            newest.Add(item);
        //        }
        //    }
        //    var eventos27 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 27 && p.HoraInicio.Value.Hour < 13).ToList();
        //    var eventos28 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 28 && p.HoraInicio.Value.Hour < 13).ToList();
        //    var eventos29 = _context.Evento.Where(p => p.HoraInicio.Value.Day == 29 && p.HoraInicio.Value.Hour < 13).ToList();
        //    foreach (var item in newest)
        //    {
        //        var participante = new Model.Participante
        //        {
        //            Email = item.Email,
        //            Procedencia = item.Procedencia,
        //            Nombre = $"{item.Nombre} {item.Apellidos}"
        //        };
        //        participante.Institucion = "";
        //        if (participante.Procedencia == null)
        //        {
        //            participante.Procedencia = "";
        //        }
        //        _context.Participante.Add(participante);
        //        await _context.SaveChangesAsync();
        //        foreach (var evento in eventos27)
        //        {
        //            var Registro = new Model.Registro
        //            {
        //                EventoId = evento.Id,
        //                ParticipanteId = participante.Id,
        //                HoraDeRegistro = DateTime.Now.ToUniversalTime()
        //            };
        //            evento.Cupo = evento.Cupo - 1;
        //            _context.Registro.Add(Registro);
        //            _context.Evento.Update(evento);
        //        }
        //        foreach (var evento in eventos28)
        //        {
        //            var Registro = new Model.Registro
        //            {
        //                EventoId = evento.Id,
        //                ParticipanteId = participante.Id,
        //                HoraDeRegistro = DateTime.Now.ToUniversalTime()
        //            };
        //            evento.Cupo = evento.Cupo - 1;
        //            _context.Registro.Add(Registro);
        //            _context.Evento.Update(evento);
        //        }
        //        foreach (var evento in eventos29)
        //        {
        //            var Registro = new Model.Registro
        //            {
        //                EventoId = evento.Id,
        //                ParticipanteId = participante.Id,
        //                HoraDeRegistro = DateTime.Now.ToUniversalTime()
        //            };
        //            evento.Cupo = evento.Cupo - 1;
        //            _context.Registro.Add(Registro);
        //            _context.Evento.Update(evento);
        //        }
        //        await _context.SaveChangesAsync();
        //    }
        //}
    }
}