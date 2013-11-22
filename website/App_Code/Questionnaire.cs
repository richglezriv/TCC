using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Questionnaire
/// </summary>
public class Questionnaire
{
    #region [Properties]
    //question name
        public String Question { get; set;}
        //question id        
    public int Id { get; set; }
    #endregion

    public Questionnaire()
    {
        //
        // TODO: Add constructor logic here
        //
        
    }

    public static List<Questionnaire> GetByType(String typeOf){
        List<Questionnaire> list = new List<Questionnaire>();

        try{
            Subject s = Subject.GetBy(typeOf);

            if (s == null)
                list.Add(new Questionnaire() { Id = 0, Question = "No existe el tema de cuestionario"});

            var db = WebMatrix.Data.Database.Open("db_psichs");
            String queryString = "SELECT ID, QUESTION FROM vw_questionnaire WHERE ID_EVAL = @0";
            
            foreach(var o in db.Query(queryString, s.Id)){
                list.Add(new Questionnaire() { Id = o.ID, Question = o.QUESTION});
            }

            if (list.Count.Equals(0))
                list.Add(new Questionnaire() { Id = 0, Question = "No existe preguntas del cuestionario"});
            db.Close();
            db.Dispose();
        }
        catch (Exception){ throw;}

        return list;
    }
}
