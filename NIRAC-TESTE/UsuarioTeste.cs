using Microsoft.VisualStudio.TestTools.UnitTesting;
using NIRAC_API.Controllers;
using NIRAC_BUSINESS.Models.DAO;
using NIRAC_BUSINESS.Models.DTO;
namespace NIRAC_TESTE
{
    [TestClass]
    public class UsuarioTeste
    {
        private UsuarioController usuarioController;
        private UsuarioDAO UsuarioAntigoDAO;
        private UsuarioDTO UsuarioAntigoDTO;
        public UsuarioTeste()
        {
            this.UsuarioAntigoDAO = new UsuarioDAO();
            this.UsuarioAntigoDTO = new UsuarioDTO();
            this.usuarioController = new UsuarioController();
        }
        #region TESTES UNITÁRIOS
        //[TestMethod]
        //public void Post()
        //{
        //    UsuarioAntigoDAO.Data_Cadastro = DateTime.Now;
        //    UsuarioAntigoDAO.Data_Update = DateTime.Now;
        //    var response = usuarioController.Post(UsuarioAntigoDAO);
        //    Assert.IsNotNull(UsuarioAntigoDAO.Id);
        //    usuarioController.Delete(usuarioController._serv.DTOToDAO(response));
        //}
        [TestMethod]
        public void GetAll()
        {
            var response = usuarioController.GetAll();
            throw new System.Exception("ERRO MALUCO");
            Assert.IsNotNull(null);
            //    dotnet vstest C:\Users\Usuario\Desktop\NIRAC\NIRAC-WEB\NIRAC-TESTE\bin\Debug\NIRAC-TESTE.dll
        }

        [TestMethod]
        public void Get()
        {
            var response = usuarioController.Get(4);
            Assert.AreEqual(4, response.Id);
        }

        //[TestMethod]
        //public void Put()
        //{
        //    var response = usuarioController.Get(10);
        //    response.Tipo = "Alterado";
        //    UsuarioDTO usuarioDTO = usuarioController.Put(usuarioController._serv.DTOToDAO(response));
        //    Assert.AreEqual("Alterado", usuarioDTO.Tipo);
        //}
        //[TestMethod]
        //public void Delete()
        //{
        //    var response = usuarioController.Get(9);
        //    UsuarioDTO usuarioDTO = usuarioController.Delete(usuarioController._serv.DTOToDAO(response));
        //    Assert.AreEqual(9, usuarioDTO.Id);
        //}
        #endregion
        #region TESTES FLUXOS
        //[TestMethod]
        //public void TesteCRUD()
        //{
        //    //POST
        //    UsuarioAntigoDAO.Data_Cadastro = DateTime.Now;
        //    UsuarioAntigoDAO.Data_Update = DateTime.Now;
        //    var responsePOST = usuarioController.Post(UsuarioAntigoDAO);
        //    //GETALL COM FIND NO USUARIO ADICIONADO
        //    var responseGETALL = usuarioController.GetAll().Find(c=>c.Id == responsePOST.Id);
        //    //GET NAQUELE USUARIO
        //    var responseGET = usuarioController.Get(responsePOST.Id);
        //    //UPDATE TIPO USUARIO
        //    responseGET.Tipo = "Alterado";
        //    UsuarioDTO usuarioDTO = usuarioController.Put(usuarioController._serv.DTOToDAO(responseGET));
        //    //DELETE USUARIO
        //    UsuarioDTO usuarioDTODELETE = usuarioController.Delete(usuarioController._serv.DTOToDAO(responseGET));
        //    Assert.IsNotNull(UsuarioAntigoDAO.Id);
        //    Assert.IsNotNull(responseGETALL);
        //    Assert.AreEqual(responsePOST.Id, responseGET.Id);
        //    Assert.AreEqual("Alterado", usuarioDTO.Tipo);
        //    Assert.AreEqual(responsePOST.Id, usuarioDTO.Id);
        //}
        #endregion

    }
}
