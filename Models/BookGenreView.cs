﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM2_VuHaiDuong.Models
{
    public class BookGenreView
    {
        public List<Book>? Books { get; set; }
        public SelectList? Genres { get; set; }
        public string? BookGenre { get; set; }
        public string? SearchString { get; set; }
    }
}
