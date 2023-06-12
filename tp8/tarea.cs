namespace tarea
{

    public class Tarea
    {
        private int id;
        private string? descripcion;
        private int duracion;

        public int Id { get => id; set => id = value; }
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public Tarea(int id, string? descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
            Random random = new Random();
            int numeroAleatorio = random.Next(10, 101);
            this.duracion = numeroAleatorio;
        }
    }
}