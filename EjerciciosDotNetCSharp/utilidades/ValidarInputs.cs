using System;
using System.Text.RegularExpressions;

namespace EjerciciosDotNetCSharp.utilidades
{
    public class ValidarInputs
    {
        public static String VI_URI = "uri";
        public static String VI_URL = "url";
        public static String VI_NUMERIC = "numeric";
        public static String VI_NUMERIC_DECIMAL = "numeric_decimal";
        public static String VI_EMAIL = "email";
        public static String VI_STRING = "string";

        public String valInput(String val, String type, Int32 length, Boolean empty, String field)
        {
            return tle(val, type, length, empty, field);
        }

        private String tle(String val, String type, Int32 length, Boolean empty, String field)
        {
            if (val == null)
            {
                return "El campo '" + field + "' no puede ser nulo";
            }
            if (empty == false && val.Length == 0)
            {
                return "El campo '" + field + "' no puede estar vacio";
            }
            else if (empty == false && val.Length > 0)
            {
                return t(val, type, length, field);
            }
            else if (empty == true && val.Length > 0)
            {
                return t(val, type, length, field);
            }
            else
            {
                return "";
            }
        }

        private String t(String val, String type, Int32 length, String field)
        {
            String response;
            String pattern;
            String mensaje;
            switch (type)
            {
                case "uri":
                    pattern = "^[0-9a-zA-Z-]*$";
                    mensaje = "El campo '" + field + "' solo acepta los siguientes caracteres 0-9 a-z A-Z - ";
                    response = this.val(val, pattern, mensaje);
                    break;
                case "url":
                    pattern = "^(http|https)\\://[a-zA-Z0-9\\-\\.]+\\.[a-zA-Z]{2,3}(/\\S*)?$";
                    mensaje = "Ingresa una URL valida en el campo '" + field + "'";
                    response = this.val(val, pattern, mensaje);
                    break;
                case "numeric":
                    pattern = "^[0-9]*$";
                    mensaje = "Ingresa un valor numérico valido en el campo '" + field + "'";
                    response = this.val(val, pattern, mensaje);
                    break;
                case "numeric_decimal":
                    pattern = "^[0-9,]*\\.?[0-9]*$";
                    mensaje = "Ingresa un valor decimal valido en el campo '" + field + "'";
                    response = this.val(val, pattern, mensaje);
                    break;
                case "email":
                    pattern = "^[^@\\s]+@[^@\\.\\s]+(\\.[^@\\.\\s]+)+$";
                    mensaje = "Ingresa un correo electrónico valido en el campo '" + field + "'";
                    response = this.val(val, pattern, mensaje);
                    break;
                case "string":
                    response = "";
                    break;
                default:
                    response = "Error al validar el tipo de dato del campo '" + field + "'";
                    break;
            }
            return this.l(val, response, length, field);
        }

        private String l(String val, String response, Int32 length, String field)
        {
            if (response.Equals(""))
            {
                if (val.Length <= length)
                {
                    return "";
                }
                else
                {
                    return "La longitud del campo '" + field + "' no puede ser mayor a " + length;
                }
            }
            else
            {
                return response;
            }
        }

        public String val(String val, String pattern, String message)
        {
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(val);
            if (m.Success)
            {
                return "";
            }
            else
            {
                return message;
            }
        }

    }
}
