import requests, bs4
from databases.connection_database import Movie, connection_database

headers = {
    'Referer': 'https://stips.co.il/explore',
    'User-Agent': 'Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36',
    'Accept': 'application/json, text/plain, */*',
    'Origin': 'https://stips.co.il',
}

class Parser: 
    
    @staticmethod
    def __get_film_array_attributes(bs4_request_page): 
        array_movie_attributes : array = [ False for _ in range(5) ]
            
        array_movie_attributes[0] = bs4_request_page.find("h1", { "class": "watchTitle__title watchTitle__title_hide font-1160-42-44 font-600-36-40 font-320-28-32".split(" ")}).text
        
        array_movie_attributes[1] = bs4_request_page \
            .find("div", { "class": "fixedSlimPosterBlock__title" }).text \
            + " " \
            + bs4_request_page.find("div", { "class": "fixedSlimPosterBlock__secondTitle" }).text
        
        array_movie_attributes[2] = bs4_request_page.find("ul", { "class": "watchParams__paramsList" }) \
            .find("a", { "class": "nbl-link nbl-link_style_wovou".split(" ") }).text
        
        array_movie_attributes[3] = tuple( link.text for link in bs4_request_page \
            .findAll("ul", { "class": "watchParams__paramsList" })[1] \
            .findAll("a", { "class": "nbl-link nbl-link_style_wovou".split(" ") }) )
        
        new_string : str = ""; 
        for char in bs4_request_page.find("div", { "class": "nbl-ratingPlate__value" }).text:
            new_string += "." if char == "," else char

        array_movie_attributes[4] = float(new_string)

        new_string = ""
        for char in array_movie_attributes[0]: 
            if char == "(": 
                break;
            new_string += char; 
        array_movie_attributes[0] = new_string;

        new_string = array_movie_attributes[3][1]; 
        for i in range(2, len(array_movie_attributes[3])): 
            new_string += ", " + array_movie_attributes[3][i]; 
        array_movie_attributes[3] = new_string 

        return array_movie_attributes; 

    @staticmethod
    def parse_movies_to_database(pages_length): 
        url_ivi : str = "https://www.ivi.ru"; 
        for link_page in ( "", ) + tuple( "page" + f"{i}" for i in range(2, pages_length) ): 
            bs4_request_get_list_movies_string = bs4.BeautifulSoup(requests.get(url_ivi + "/series/2024/" + link_page, headers=headers ).text, "html.parser")
            for link_movie in bs4_request_get_list_movies_string.findAll("a", { "class": "nbl-slimPosterBlock nbl-slimPosterBlock_type_poster nbl-slimPosterBlock_status_default nbl-slimPosterBlock_iconStatus_none nbl-slimPosterBlock_available genre__nbl-slimPosterBlock".split(" ") }): 
                array_movie_attributes : array = Parser.__get_film_array_attributes(bs4.BeautifulSoup(requests.get(url_ivi + link_movie["href"], headers=headers ).text, "html.parser"))
                
                connection_database.add(
                    Movie(
                        appelation=array_movie_attributes[0],
                        director_fio=array_movie_attributes[1],
                        create_year=array_movie_attributes[2],
                        style=array_movie_attributes[3], 
                        raiting=array_movie_attributes[4]) )
                
        connection_database.commit()  

