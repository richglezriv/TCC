using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Subject
/// </summary>
public class Subject
{
    public Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Id { get; set; }

    public String TypeOf { get; set; }

    public String Name { get; set; }

    public static Subject GetBy(String typeOf){
        
        Subject s = null;
        
        String query = "SELECT id, name, type_of FROM c_evaluation WHERE type_of = @0";

        try{
        var db = WebMatrix.Data.Database.Open("db_psichs");
        var result = db.QuerySingle(query, typeOf);

        s = new Subject(){
            Id = result.id,
            Name = result.name,
            TypeOf = result.type_of
        };

        db.Close();
        db.Dispose();
        
        }
        catch (Exception){
            throw;
        }

        return s;
    }
}
