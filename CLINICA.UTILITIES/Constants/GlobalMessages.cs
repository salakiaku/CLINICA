using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.UTILITIES.Constants
{
    public static class GlobalMessages
    {

        public const string GetSuccess = "Consulta realizada com sucesso!";
        public const string GetNotFound = "Registro não encontrado!";
        public const string PostSuccess = "Registro criado com sucesso!";
        public const string PostFailed = "Erro ao criar o registro. Verifique os dados informados.!";
        public const string PutSuccess = "Registro actualizado com sucesso!";
        public const string PutFailed = "Não foi possível actualizar o registro!";
        public const string DeleteSuccess = "Registro excluído com sucesso!";
        public const string DeleteFailed = "Não foi possível excluir o registro!";
        public const string InternalServerError = "Ocorreu um erro inesperado no servidor!";
        public const string UnAuthorized = "Acesso não autorizado!";
        public const string ForBiden = "Você não tem permissão para realizar essa ação.";

    }
}
