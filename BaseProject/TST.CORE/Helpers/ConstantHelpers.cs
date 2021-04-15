using TST.CORE.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace TST.CORE.Helpers
{
    public static class ConstantHelpers
    {

        public const string PROJECT = "Proyecto Prueba";
        public static class GENERAL
        {

        }

        public static class ENTITIES
        {
            public static class USER
            {
                public static class SEX
                {
                    public const byte MALE = 1;
                    public const byte FERMALE = 2;
                    public const byte UNSPECIFIED = 3;

                    public static Dictionary<int, string> VALUES = new Dictionary<int, string>()
                    {
                        { MALE, "Masculino" },
                        { FERMALE, "Femenino" },
                        { UNSPECIFIED, "Sin Especificar" },
                    };
                }

            }
        }
        public static class CONFIGURATION
        {
           
        }
        public static class ROLES
        {

        }
        public static class SELECT2
        {
            public static class DEFAULT
            {
                public const int PAGE_SIZE = 10;
            }

            public static class SERVER_SIDE
            {
                public static class REQUEST_PARAMETERS
                {
                    public const string CURRENT_PAGE = "page";
                    public const string QUERY = "q";
                    public const string REQUEST_TYPE = "_type";
                    public const string SEARCH_TERM = "term";
                }

                public static class REQUEST_TYPE
                {
                    public const string QUERY = "query";
                    public const string QUERY_APPEND = "query_append";
                }
            }
        }
        public static class DATATABLE
        {
            public static class SERVER_SIDE
            {
                public static class DEFAULT
                {
                    public const string ORDER_DIRECTION = "DESC";
                }

                public static class SENT_PARAMETERS
                {
                    public const string DRAW_COUNTER = "draw";
                    public const string PAGING_FIRST_RECORD = "start";
                    public const string RECORDS_PER_DRAW = "length";
                    public const string SEARCH_VALUE = "search[value]";
                    public const string SEARCH_REGEX = "search[regex]";
                    public const string ORDER_COLUMN = "order[0][column]";
                    public const string ORDER_DIRECTION = "order[0][dir]";
                }
            }
        }
        public static class PAGINATION
        {
            public static class SERVER_SIDE
            {
                public static class SENT_PARAMETERS
                {
                    public const string PAGE = "page";
                    public const string RECORDS_PER_DRAW_PAGINATION = "rpdraw";
                    public const string SEARCH_VALUE_PAGINATION = "srch";
                }
            }
        }
        public static class MONTHS
        {
            public const int JANUARY = 1;
            public const int FEBRAURY = 2;
            public const int MARCH = 3;
            public const int APRIL = 4;
            public const int MAY = 5;
            public const int JUNE = 6;
            public const int JULY = 7;
            public const int AUGUST = 8;
            public const int SEPTEMBER = 9;
            public const int OCTOBER = 10;
            public const int NOVEMBER = 11;
            public const int DECEMBER = 12;

            public static Dictionary<int, string> VALUES = new Dictionary<int, string>()
            {
                { JANUARY, "Enero" },
                { FEBRAURY, "Febrero" },
                { MARCH, "Marzo" },
                { APRIL, "Abril" },
                { MAY, "Mayo" },
                { JUNE, "Junio" },
                { JULY, "Julio" },
                { AUGUST, "Agosto" },
                { SEPTEMBER, "Setiembre" },
                { OCTOBER, "Octubre" },
                { NOVEMBER, "Noviembre" },
                { DECEMBER, "Diciembre" }
            };
        }
        public static class FORMATS
        {
            public const string DATE = "dd/MM/yyyy";
            public const string DURATION = "{0}h {1}m";
            public const string TIME = "h:mm tt";
            public const string DATETIME = "dd/MM/yyyy h:mm tt";
        }
        public static class TIMEZONEINFO
        {
            public const bool DisableDaylightSavingTime = true;
            public const int Gmt = -5;
            public const string LINUX_TIMEZONE_ID = "America/Bogota";
            public const string OSX_TIMEZONE_ID = "America/Cayman";
            public const string WINDOWS_TIMEZONE_ID = "SA Pacific Standard Time";
        }
        public static class HTML
        {
            public static class COLOR
            {
                public const string BRAND = "brand";
                public const string METAL = "metal";
                public const string PRIMARY = "primary";
                public const string SUCCESS = "success";
                public const string INFO = "info";
                public const string WARNING = "warning";
                public const string DANGER = "danger";
                public const string FOCUS = "focus";
                public const string ACCENT = "accent";

                private static Dictionary<int, string> INDICES = new Dictionary<int, string>()
                {
                    { 1, BRAND },
                    { 2, METAL },
                    { 3, PRIMARY},
                    { 4, SUCCESS },
                    { 5, INFO },
                    { 6, WARNING },
                    { 7, DANGER },
                    { 8, FOCUS }
                };

                public static string RANDOM_COLOR()
                {
                    var random = new System.Random();
                    var number = random.Next(1, 8);
                    return INDICES[number];
                }

            }
        }
        public class SEQUENCE_ORDER
        {
            public const byte NINGUNO = 0;
            public const byte FIRST = 1;
            public const byte SECOND = 2;
            public const byte THIRD = 3;
            public const byte FOURTH = 4;
            public const byte FIFTH = 5;
            public const byte SIXTH = 6;
            public const byte SEVENTH = 7;
            public const byte EIGHTH = 8;
            public const byte NINETH = 9;
            public const byte TENTH = 10;

            public static Dictionary<int, string> VALUES = new Dictionary<int, string>
                {
                    { NINGUNO, "Sin Asignar" },
                    { FIRST, "PRIMERO" },
                    { SECOND, "SEGUNDO" },
                    { THIRD, "TERCERO" },
                    { FOURTH, "CUARTO" },
                    { FIFTH, "QUINTO" },
                    { SIXTH, "SEXTO" },
                    { SEVENTH, "SÉPTIMO" },
                    { EIGHTH, "OCTAVO" },
                    { NINETH, "NOVENO" },
                    { TENTH, "DÉCIMO" },
                };
        }
        public class DOCUMENT_TYPE
        {
            public const byte DNI = 1;
            public const byte PASSPORT = 2;
            public const byte INMIGRATION_CARD = 3;
            public const byte TEMPORARY_RESIDENCE_CARD = 4;
            public const byte IDENTITY_CARD = 5;

            public static Dictionary<byte, string> VALUES = new Dictionary<byte, string>
                {
                    { DNI, "D.N.I." },
                    { PASSPORT, "Pasaporte" },
                    { INMIGRATION_CARD, "Carné  de extranjería" },
                    { TEMPORARY_RESIDENCE_CARD, "Carné temporal de permanencia" },
                    { IDENTITY_CARD, "Doc. identificación personal" },
                };
        }


        public static class WEEKDAY
        {
            public static string GetWeekDayName(string dayOfWeek)
            {
                if (dayOfWeek == DayOfWeek.Monday.ToString())
                    return "Lunes";
                if (dayOfWeek == DayOfWeek.Tuesday.ToString())
                    return "Martes";
                if (dayOfWeek == DayOfWeek.Wednesday.ToString())
                    return "Míercoles";
                if (dayOfWeek == DayOfWeek.Thursday.ToString())
                    return "Jueves";
                if (dayOfWeek == DayOfWeek.Friday.ToString())
                    return "Viernes";
                if (dayOfWeek == DayOfWeek.Saturday.ToString())
                    return "Sábado";
                if (dayOfWeek == DayOfWeek.Sunday.ToString())
                    return "Domingo";

                return string.Empty;
            }
        }
    }
}
