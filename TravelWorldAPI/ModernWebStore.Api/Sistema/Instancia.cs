using ModernWebStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModernWebStore.Api.Sistema
{ 
    public class Instancia
    {
        private static IUserApplicationService _usuarioApplication;

        private Instancia(IUserApplicationService usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        public static IUserApplicationService Instance
        {
            get
            {
                return _usuarioApplication;
            }
        }
    }
}
