using Mt22KpfuRu.Models;

namespace Mt22KpfuRu.Instruments;

public static class DataBank
{
    public static IndexModel IndexModel { get; set; }
    public static ProgramModel ProgramModel { get; set; }
    public static ConferencesModel ConferencesModel { get; set; }
    public static KazanModel KazanModel { get; set; }
    public static ExcursionModel ExcursionModel { get; set; }
    public static MapModel MapModel { get; set; }

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
                },
                new News()
                {
                    Id = 2,
                    Title = "Продление регистрации",
                    Description = "Регистрация проделена до 18 ноября включительно",
                    Content = "<a href=\"https://kpfu.ru/science/nauchno-issledovatelskaya-rabota-studentov-nirs/materialy-i-tehnologii-xxi-veka-xxi-veka/registraciya\">Регистрация</a> продлена <strong>до 18.11.2022 включительно</strong>.",
                    CreateTime = new DateTime(2022,11,11,19,15,00)
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
                    DateTime = new DateTime(2022,11,18),
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
                new FastLink() {Name = "История конференции", Url = "/Home/Conferences"},
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
        List<KazanPlace> kazanPlaces = new List<KazanPlace>()
        {
            new KazanPlace() { Name = "Казанский Кремль", Description = "Древнейшая часть Казани, комплекс архитектурных, исторических и археологических памятников, раскрывающих многовековую историю города: археологические остатки первого (XII—XIII вв.), второго (XIV—XV вв.) и третьего городищ (XV—XVI вв.); белокаменный кремль, ряд храмов и зданий, имеющих большую историко-архитектурную и культурную ценность, официальная резиденция Президента Татарстана. Является объектом Всемирного наследия ЮНЕСКО с 2000 года.", Image = "kazan1.jpg" },
            new KazanPlace() { Name = "Спасская башня Казанского Кремля", Description = "Четырехъярусная Спасская башня с надвратной церковью Спаса Нерукотворного — главный въезд в Казанский кремль — расположена в южном прясле крепостной стены. Возведена в XVI веке псковскими зодчими Иваном Ширяем и Постником Яковлевым по прозванию «Барма». Башня неоднократно перестраивалась, во все века ей как главной кремлевской башне уделяли особое внимание.", Image = "kazan2.jpg" },
            new KazanPlace() { Name = "Благовещенский собор", Description = "Благовещенский собор — самое крупное сооружение Казанского кремля и древнейшее из сохранившихся каменных построек Казани, расположен в центре комплекса. Построен в 1561—1562 гг. псковскими мастерами во главе с Постником Яковлевым и Иваном Ширяем. Перестроен в 1691, 1736, 1835—1843, реконструирован в 1970—1980-е, реставрировался в 1996—2005 гг.", Image = "kazan3.jpg"},
            new KazanPlace() { Name = "Планетарий КФУ", Description = "«Планетарий в Казани – единственный в России, который действует в составе университета», – сказал, обращаясь к собравшимся на церемонию открытия, Ильшат Гафуров. Он добавил, что новый планетарий «полностью вписывается в структуру университета и будет служить его научному сообществу». Подробности: <a class=\"text-light\" href=\"http://kpfu.ru/news/v-kazanskom-federalnom-universitete-otkryli-45952.html\">здесь</a>", Image = "kazan4.jpg" },
            new KazanPlace() { Name = "Симуляционный центр КФУ", Description = "Научно-исследовательское и культурно-образовательное учреждение, ведущий музейный центр Татарстана и один из крупнейших культурно-исторических музеев в Поволжье.", Image = "kazan5.jpg" }
        };
        KazanModel = new KazanModel()
        {
            Places = kazanPlaces
        };
        List<ExcursionPart> excursions = new List<ExcursionPart>()
        {
            new ExcursionPart() { Name = "Симуляционный центр КФУ", Description = "Высокие медицинские технологии создают потребность в компетентных и прогрессивных специалистах. В этом отношении в Институте фундаментальной медицины и биологии КФУ для подготовки врачей используются самые инновационные разработки. На площади 400 квадратных метров создана виртуальная больница, где есть палаты разной направленности - приемный покой, кабинет эндоскопии, виртуальная операционная, виртуальная интенсивная терапия, родильное отделение, отделение педиатрии, детская реанимационная.", Image1 = "exc-1.jpg" },
            new ExcursionPart() { Name = "Музей истории и Зоологический музей КФУ", Description = "Музеи КФУ имеют международный статус. Информация об их фондах содержится в Международных каталогах и справочниках. Экспозиции и фонды музеев широко используются в учебных, научных и культурно–просветительских целях.\r\nЗоологический музей КФУ относится к числу старейших в России хранилищ этого профиля, а по богатству и исторической ценности коллекций является одним из самых значительных зоологических музеев страны. Сегодня музей состоит из восьми залов, расположенных по фасаду второго этажа восточного крыла главного здания университета. Коллекция музея включает экспонаты из двадцати трёх типов животных. Его фонды насчитывают 3,5 тысячи единиц хранения позвоночных, 750 единиц хранения насекомых (30-40 тысяч экземпляров), 4 тысячи экземпляров и единиц хранения других беспозвоночных.", Image1 = "exc-2.jpg", Image2 = "exc-3.jpg" },
            new ExcursionPart() { Name = "Геологический музей КФУ и 3D-Geo центр", Description = "Геологический музей КФУ - один из старейших и богатейших естественнонаучных музеев России, которые начали создаваться при высших учебных заведениях в конце XVIII столетия. В музее более 150000 музейных предметов из 60 стран мира. Это собрания метеоритов, горных пород,минералов, руд, ископаемых останков древних растений и животных.\r\n3D-Geo центр был создан в 2013 г. для введения образовательных и научных проектов в области геологического и гидродинамического моделирования.", Image1 = "exc-4.jpg", Image2 = "exc-5.jpg" }
        };
        ExcursionModel = new ExcursionModel()
        {
            Parts = excursions
        };
        MapModel = new MapModel()
        {
            YandexFrame = "<iframe src=\"https://yandex.ru/map-widget/v1/?um=constructor%3Ab75ac822ac159b3eda9e9a7b43cac62db4f5e8ff234b06031aee6b5542f4ecfb&amp;source=constructor\" width=\"100%\" height=\"660\" frameborder=\"0\"></iframe>"
        };
    }
}
