using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for PsichsController
/// </summary>
public class PsichsController
{
    private static String m_name;
    private static String m_mail;
    private static String m_comments;

    public PsichsController()
    {
        //
        // TODO: Add constructor logic here
        //
        
    }

    public static List<Questionnaire> GetBy(String type){
        
        return Questionnaire.GetByType(type);   
        

    }

    public static void SendContactMail(String name, String mail, String comments){
        
        try{
            m_name = name;
            m_mail = mail;
            m_comments = comments;

            BSoft.MailProvider.DestinationEntity destination = new BSoft.MailProvider.DestinationEntity();
            destination.IsHtmlEncoded = true;
            destination.MailAdress = "abraham.gonzalez@tododepollo.com.mx";
            destination.Name = "Ricardo Gonzalez";
            destination.MailBody = GetBody();
            destination.Subject = "Solicitud de Contacto";
        
            BSoft.MailProvider.MailControl control = BSoft.MailProvider.MailControl.GetInstance();
            control.SendContactInformation(destination);
        }
        catch (BSoft.MailProvider.MailControlException){
            throw;
        }
    }

    private static String GetBody(){
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        builder.AppendLine("<!DOCTYPE html>");
        builder.AppendLine("<html>");

        builder.AppendLine("<head>");
        builder.AppendLine("<meta content='text/html; charset=utf-8' http-equiv='Content-Type'>");
        builder.AppendLine("<title>Contacto de Correo</title>");
        builder.AppendLine("<style>");
        builder.AppendLine("body {");
        builder.AppendLine("	font-family:Arial, Helvetica, sans-serif; #000000 !important;");
        builder.AppendLine("}");
        builder.AppendLine("ul {");
        builder.AppendLine("	list-style:none; #000000 !important;");
        builder.AppendLine("}");
        builder.AppendLine("label{");
        builder.AppendLine("	width:150px;");
        builder.AppendLine("	float:left;");
        builder.AppendLine("	#000000 !important;");
        builder.AppendLine("}");
        builder.AppendLine("span {");
        builder.AppendLine("	font-size:x-small;");
        builder.AppendLine("	#000000 !important;");
        builder.AppendLine("}");
        builder.AppendLine("</style>");
        builder.AppendLine("</head>");

        builder.AppendLine("<body>");

        builder.AppendLine("<p>Se ha generado la siguiente información de contacto:</p>");
        builder.AppendLine("<ul>");
        builder.AppendLine("	<li><label>Nombre</label>"+m_name+"</li>");
        builder.AppendLine("	<li><label>Correo</label>"+m_mail+"</li>");
        builder.AppendLine("	<li><label>Comentarios</label>"+m_comments+"</li>");
        builder.AppendLine("</ul>");
        builder.AppendLine("<p><span>Este correo es autogenerado, si usted no es el remitente por favor sírvase a contestar este mismo a ");
        builder.AppendLine("<a href='mailto:contacto@terapiacognitivoconductual.com.mx'>contacto</a> y elimine el mismo de su buzón.</span></p>");
        builder.AppendLine("</body>");

        builder.AppendLine("</html>");

        return builder.ToString();

    }
}
