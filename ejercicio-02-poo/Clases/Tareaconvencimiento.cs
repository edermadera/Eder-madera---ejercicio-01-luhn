  public class TareaConVencimiento : Tarea
    {
       
        public DateTime FechaVencimiento { get; set; }

      
        public int DiasRestantes
        {
            get
            {
                return (FechaVencimiento.Date - DateTime.Now.Date).Days;
            }
        }

       
        public TareaConVencimiento() : base()
        {
            FechaVencimiento = DateTime.Now.AddDays(7);
        }

            public override void MostrarInfo()
        {
            
            base.MostrarInfo();

            Console.WriteLine($"Fecha de vencimiento: {FechaVencimiento:d}");
            Console.WriteLine($"Días restantes: {DiasRestantes}");
           
        }
    }
}
