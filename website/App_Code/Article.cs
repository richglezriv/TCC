using System;
using System.Collections.Generic;
using System.Web;

/// <summary>
/// Summary description for Article
/// </summary>
public class Article
{
    #region Properties
    public int Id { get; set; }
    public String Title { get; set; }
    public String Content { get; set; }
    public DateTime Created { get; set; }
    public String UserRegistered { get; set; }
    #endregion

    public Article()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<Article> GetAll(){
        List<Article> articles = new List<Article>();
         
        try{
        var db = WebMatrix.Data.Database.Open("db_psichs");
        String queryString = "SELECT * FROM vw_articles";
        
        foreach(var a in db.Query(queryString)){
            articles.Add(new Article(){
               Id = a.ID,
               Title = a.TITLE,
               Content = a.ARTICLE,
               Created = a.REGISTERED,
               UserRegistered = a.USR_CREATE
            });
        }
        }
        catch (Exception){
            
        }

        return articles;
    }
}
