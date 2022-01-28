using System;
using System.Xml;

namespace ConsoleApp1
{
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование от банка Сетелем.");
            Console.WriteLine("Задача: Есть сервис ЦБ по получению информации о курсах валют: https://cbr.ru/DailyInfoWebServ/DailyInfo.asmx Необходимо сделать приложение, которое будет обращаться к этому сервису и выводить информацию о текущих курсах рубля к доллару и евро");
            Console.WriteLine("Кандидат: Ядыкин Н.Э.\n\n");

            Console.WriteLine("Подключение к сервису ЦБ РФ...");
            SoapCbr.DailyInfoSoapClient objSoapClient = new SoapCbr.DailyInfoSoapClient();
            XmlNode objXmlNode = objSoapClient.GetCursOnDateXML(DateTime.Now);

            Console.WriteLine("Курсы валют на сегодня:");
            foreach (XmlNode objNode in objXmlNode.ChildNodes)
                switch (objNode["Vcode"].FirstChild.Value)
                {
                    case "840":                        
                    case "978":
                        Console.WriteLine("{0} - {1}", objNode["Vname"].FirstChild.Value.TrimEnd(' '), objNode["Vcurs"].FirstChild.Value);
                        break;
                }
            Console.WriteLine("Данные получены, программа завершена.");

            Console.WriteLine("Нажмите ввод для завершения...");
            Console.ReadLine();
        }
    }
}
