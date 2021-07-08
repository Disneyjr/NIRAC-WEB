﻿using NIRAC_BUSINESS.Context;
using NIRAC_BUSINESS.Interface;
using NIRAC_BUSINESS.Models.DAO;

namespace NIRAC_BUSINESS.Repository
{
    public class EmpresaUsuarioRepository : RepositoryBase<ContextDb, EmpresaUsuarioDAO>
    {
        public EmpresaUsuarioRepository(ContextDb cx) : base(cx)
        {
        }
    }
}
