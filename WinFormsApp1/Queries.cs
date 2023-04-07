using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAI
{
    internal class Queries
    {
        public static readonly string Login = "SELECT Сотрудник.Код, Логин, Пароль, Фамилия, Имя, Отчество, Наименование " +
                                              "FROM Сотрудник, Звание WHERE Звание.Код = [Код звания] AND Логин = @login";
        public static readonly string GetViolations = "SELECT * FROM Нарушение";
        public static readonly string GetRegistrations = "SELECT * FROM Регистрация";
        public static readonly string GetLicenses = "SELECT * FROM [Водительское удостоверение]";
    }
}
