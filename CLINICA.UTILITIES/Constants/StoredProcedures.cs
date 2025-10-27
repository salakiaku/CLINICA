using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICA.UTILITIES.Constants
{
    public class StoredProcedures
    {
        public static class STP
        {
            #region Analysis Stored Procedure
            public const string STPAnalysisDelete = "stp_Analysis_Delete";
            public const string STPAnalysisCreate = "stp_Analysis_Create";
            public const string STPAnalysisGetByFilters = "stp_Analysis_GetByFilters";
            public const string STPAnalysisGetById = "stp_Analysis_GetById";
            public const string STPAnalysisUpdate = "stp_Analysis_Update";
            public const string STPAnalysisUpdateState = "stp_Analysis_Update_State";
            #endregion
            #region Exams Stored Procedure  
            public const string STPExamsGetByFilters = "stp_Exams_GetByFilters";
            public const string STPExamsGetById = "stp_Exams_GetById";
            public const string STPExamsCreate = "stp_Exams_Create";
            public const string STPExamsUpdate = "stp_Exams_Update";
            public const string STPExamsDelete = "stp_Exams_Delete";
            public const string STPExamsUpdateState = "stp_Exams_UpdateState";

            #endregion

            #region DocumentType
            public const string STPDocumentTypeCreate = "stp_DocumentType_Create";
            public const string STPDocumentTypeUpdateState = "stp_DocumentType_UpdateState";
            public const string STPDocumentTypeUpdate = "stp_DocumentType_Update";
            public const string STPDocumentTypeGetByFilters = "stp_DocumentType_GetByFilters";
            public const string STPDocumentTypeGetById = "stp_DocumentType_GetById";

            #endregion

            #region Patients
            public const string STPPatientsCreate = "stp_Patients_Create";
            public const string STPPatientsUpdate = "stp_Patients_Update";
            public const string STPPatientsGetById = "stp_Patients_GetById";
            public const string STPPatientsGetByFilters = "stp_Patients_GetByFilters";
            public const string STPPatientsDelete = "stp_Patients_Delete";
            public const string STPPatientsUpdateState = "stp_Patients_UpdateState";
            #endregion

            #region Specialties
            public const string STPSpecialitiesCreate = "stp_Specialties_Create";
            public const string STPSpecialitiesGetByFilters = "stp_Specialties_GetByFilters";

            #endregion

            #region Medics
            public const string STPMedicsCreate = "stp_Medics_Create";
            public const string STPMedicsUpdate = "stp_Medics_Update";
            public const string STPMedicsDelete = "stp_Medics_Delete";
            public const string STPMedicsUpdateState = "stp_Medics_UpdateState";
            public const string STPMedicsGetByFilters = "stp_Medics_GetByFilters";
            public const string STPMedicsGetById = "stp_Medics_GetById";

            #endregion



        }
    }
}
