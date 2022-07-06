namespace TP_Web_Conversor.Models
{
    public class UsuarioDAO
    {
        public static UsuarioDAO instancia = null;
        public List<Usuario> usuarios = new List<Usuario>();
         
        private UsuarioDAO() { }

        public static UsuarioDAO getInstancia()
        {
            if(instancia == null)
                instancia = new UsuarioDAO();
            return instancia;
        }

        public UsuarioDAO add(Usuario u)
        {
            usuarios.Add(u);
            return this;
        }

        public Usuario getUsuarioByUser(string user)
        {
            return usuarios.Find(u => u.user == user);
        }
    }
}
