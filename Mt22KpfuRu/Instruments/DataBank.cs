using Mt22KpfuRu.Models;
namespace Mt22KpfuRu.Instruments;

public static class DataBank
{
    public static IndexModel IndexModel { get; set; }
    public static ProgramModel ProgramModel { get; set; }
    public static ConferencesModel ConferencesModel { get; set; }

    public static void Preset()
    {
        List<News> newsList = new List<News>()
            {
                new News()
                {
                    Id = 1,
                    Title = "Зеркало",
                    Description = "Появилось зеркало на сайте университета",
                    Content = "С информацией о проведении Школы-конференции в 2022 г. и регистрацией можно ознакомиться по ссылке: <a href=\"https://kpfu.ru/science/nauchno-issledovatelskaya-rabota-studentov-nirs/materialy-i-tehnologii-xxi-veka-xxi-veka\">Материалы и технологии XXI века</a>",
                    CreateTime = new DateTime(2022,10,29,17,12,00)
                }
            };
        List<Date> dateList = new List<Date>()
            {
                new Date()
                {
                    DateTime = new DateTime(2022,10,12),
                    Name = "Начало регистрации",
                    ShowTime = false
                },
                new Date()
                {
                    DateTime = new DateTime(2022,11,12),
                    Name = "Конец регистрации",
                    ShowTime = false
                },
                new Date()
                {
                    DateTime = new DateTime(2022,11,30,10,0,0),
                    Name = "Начало конференции",
                    ShowTime = true
                },
                new Date()
                {
                    DateTime = new DateTime(2022,12,2,16,0,0),
                    Name = "Конец конференции",
                    ShowTime = true
                }
            };
        List<FastLink> linkList = new List<FastLink>()
            {
                new FastLink() {Name = "Казань", Url = "/Home/Kazan"},
                new FastLink() {Name = "Информационное письмо", Url = "/docs/InfoLetter.pdf"},
                new FastLink() {Name = "Экскурсии", Url = "/Home/Excursions"},
                new FastLink() {Name = "Секции", Url = "/Home/About#Sections"},
                new FastLink() {Name = "Университет КФУ", Url = "http://kpfu.ru/"},
                new FastLink() {Name = "Пленарные докладчики", Url = "/Home/Participants"},
                new FastLink() {Name = "История коференции", Url = "/Home/Conferences"},
            };
        IndexModel = new IndexModel()
        {
            Dates = dateList,
            FastLinks = linkList,
            TotalNews = newsList
        };
        List<ProgramPart> partList = new List<ProgramPart>()
            {
                new ProgramPart()
                {
                    Date = new DateOnly(2022,11,30),
                    TimeStart = new TimeOnly(10, 00),
                    TimeEnd = new TimeOnly(13,00),
                    Name = "Регистрация",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,11,30),
                    TimeStart = new TimeOnly(14, 00),
                    TimeEnd = new TimeOnly(14,30),
                    Name = "Открытие конференции",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 108/109"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,11,30),
                    TimeStart = new TimeOnly(14, 30),
                    TimeEnd = new TimeOnly(16,00),
                    Name = "Пленарные лекции",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 108/109"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,11,30),
                    TimeStart = new TimeOnly(16, 00),
                    TimeEnd = new TimeOnly(16,30),
                    Name = "Кофе-брейк"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,11,30),
                    TimeStart = new TimeOnly(16, 30),
                    TimeEnd = new TimeOnly(18,30),
                    Name = "Секционные доклады",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 216/218"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(9, 30),
                    TimeEnd = new TimeOnly(11,00),
                    Name = "Пленарные лекции (онлайн)",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 108/109"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(11, 00),
                    TimeEnd = new TimeOnly(12,00),
                    Name = "Свободное время"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(12, 00),
                    TimeEnd = new TimeOnly(14,00),
                    Name = "Блиц доклады (по секциям)\t",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 216/218"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(14, 00),
                    TimeEnd = new TimeOnly(15,00),
                    Name = "Обед"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(15, 00),
                    TimeEnd = new TimeOnly(16,30),
                    Name = "Секционные доклады",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 216/218"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(16, 30),
                    TimeEnd = new TimeOnly(17,00),
                    Name = "Кофе-брейк"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,1),
                    TimeStart = new TimeOnly(17, 00),
                    TimeEnd = new TimeOnly(18,30),
                    Name = "Секционные доклады",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 216/218"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,2),
                    TimeStart = new TimeOnly(9, 30),
                    TimeEnd = new TimeOnly(12,00),
                    Name = "Блиц доклады (по секциям)",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 216/218"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,2),
                    TimeStart = new TimeOnly(12, 00),
                    TimeEnd = new TimeOnly(15,00),
                    Name = "Обед, свободное время"
                },
                new ProgramPart()
                {
                    Date = new DateOnly(2022,12,2),
                    TimeStart = new TimeOnly(15, 00),
                    TimeEnd = new TimeOnly(16,00),
                    Name = "Закрытие конференции",
                    Place = "<a class=\"text-light\" href=\"https://yandex.ru/maps/org/kfu/1297536680/?ll=49.122191%2C55.791870&z=16\">Кремлёвская 35</a>, каб. 108/109"
                }
            };
        ProgramModel = new ProgramModel()
        {
            TotalParts = partList
        };
        List<Conference> conferenceList = new List<Conference>()
            {
                new Conference(2021,true,true,true),
                new Conference(2018,true,true,true),
                new Conference(2016,true,true,false)
            };
        ConferencesModel = new ConferencesModel()
        {
            Conferences = conferenceList
        };
    }
}
