//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace up_wpf.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class exam
    {
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> discipline_id { get; set; }
        public Nullable<int> student_id { get; set; }
        public Nullable<int> teacher_id { get; set; }
        public string auditorium { get; set; }
        public Nullable<int> grade { get; set; }
        public int id { get; set; }
    
        public virtual discipline discipline { get; set; }
        public virtual student student { get; set; }
        public virtual teacher teacher { get; set; }
    }
}
