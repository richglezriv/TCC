using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for AdminController
/// </summary>
public class AdminController
{
    public AdminController()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static String GetUserName(int userId){
        
        try{
        var db = WebMatrix.Data.Database.Open("db_psichs");
        String queryString = "SELECT name FROM c_user WHERE id_user = @0";
        var result = db.QuerySingle(queryString, userId);

        return result.name;
        }
        catch (Exception ex){
            return "No existe el nombre de usuario";
        }
    }

    public void RegisterArticle(Article article){
        
        try{
            
            var db = WebMatrix.Data.Database.Open("db_psichs");
            
            if (article.Id.Equals(0)){
                
                db.Execute("sp_createarticle @0, @1, @2, @3", article.Title, article.Created, article.Content, int.Parse(article.UserRegistered));    

            }
            else if (article.Id > 0){
                db.Execute("sp_updatearticle @0, @1, @2", article.Id, article.Content, article.Title);
            }
            
        }
        catch (Exception){
            throw;
        }
    }

    public void DeleteArticle(int id){
        
        String queryString = "DELETE FROM d_article WHERE id_article = @0";

        try{
            var db = WebMatrix.Data.Database.Open("db_psichs");

            db.Execute(queryString, id);
        }
        catch (Exception){
            throw;
        }
    }
}
