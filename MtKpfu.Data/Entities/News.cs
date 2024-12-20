﻿using MtKpfu.Data.Interfaces;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MtKpfu.Data.Entities;

public sealed class News : IIndexable
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Укажите заголовок!")]
    [DisplayName("Заголовок:")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "Укажите краткое описание!")]
    [DisplayName("Краткое описание:")]
    public string Description { get; set; } = null!;
    [Required(ErrorMessage = "Укажите содержание новости!")]
    [DisplayName("Содержание:")]
    public string Content { get; set; } = null!;
    public DateTime CreateTime { get; set; }
}
