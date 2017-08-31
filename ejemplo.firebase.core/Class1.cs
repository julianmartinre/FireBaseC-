using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo.firebase.core
{


    public class ContextoFirebase : ICrudUsuario
    {

        IFirebaseConfig config;
        IFirebaseClient client;

        string url = "https://diploma-uai.firebaseio.com/";
        string secret = "ZSjNzguVr7miIxSHACZVJAFoOwnMLJDIRmgwHulp";

        public ContextoFirebase()
        {
            config = new FirebaseConfig()
            {
                AuthSecret = secret,
                BasePath = url
            };
            client = new FirebaseClient(config);

        }

        public void Guardar(Usuario c)
        {
            client.Push<Usuario>("Usuario/", c);
        }

        public Usuario Obtener(object id)
        {
            return client.Get("Usuario/" + id).ResultAs<Usuario>();
              
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            Dictionary<object, Usuario> res = client.Get("Usuario").ResultAs<Dictionary<object, Usuario>>();

            return res.Values.AsEnumerable<Usuario>();
        }
    }


    interface ICrudUsuario
    {
       void Guardar(Usuario c);
        Usuario Obtener(object id);

        IEnumerable<Usuario> ObtenerTodos();
    }

    public class Usuario
    {
     public string Username { get; set; }
     public string Password{ get; set; }
    }
}
