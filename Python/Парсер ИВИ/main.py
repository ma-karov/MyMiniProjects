from databases.connection_database import Movie, connection_database, sqlalchemy
from parser import Parser
from fastapi import FastAPI
from fastapi.responses import HTMLResponse
import fastapi.templating 



app = FastAPI()

#templates = fastapi.templating.Jinja2Templates()

@app.get("/")
def read_root_method_get(request: fastapi.Request):
    html_content = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Parser films</title>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"> 
            <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        </head>
        <body> 
            <form method = "POST" > 
                <button name = "ButtonRequest" value = 1 class = "btn btn-success" > Загрузить </button> 
            </form> 
        </body>
        </html>
    """

    return HTMLResponse(content=html_content)
    #return templates.TemplateResponse(request=request, name="templates/index.html", context={"request": request}) 

@app.post("/")
def read_root_method_post(request: fastapi.Request): 
    if connection_database.query(sqlalchemy.func.count(Movie.id)).scalar() == 0:
        Parser.parse_movies_to_database(3)
    tuple_movies : tuple = connection_database.query(Movie).all();
    
    html_content_begin = """
        <!DOCTYPE html>
        <html lang="en">
        <head>
            <meta charset="UTF-8">
            <meta http-equiv="X-UA-Compatible" content="IE=edge">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
            <title>Parser films</title>
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"> 
            <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
            <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
        </head>
        <body> 
            <table class = "table table-bordered" > 
                <thead> 
                    <tr> 
                        <td> Название </td> 
                        <td> Режиссер </td> 
                        <td> Год </td> 
                        <td> Жанр </td> 
                        <td> Рейтинг </td> 
                    </tr>
                </thead> 
                <tbody>
    """ 
    
    html_content = "" 
    for movie in tuple_movies:
        html_content += f"\
            <tr> \
                <td> {movie.appelation} </td> \
                <td> {movie.director_fio} </td> \
                <td> {movie.create_year} </td> \
                <td> {movie.style} </td> \
                <td> {movie.raiting} </td> \
            </tr>"
    html_content_end = """
        
                </tbody>
            </table>
        </body>
        </html>
    """

    return HTMLResponse(content=html_content_begin + html_content + html_content_end)
