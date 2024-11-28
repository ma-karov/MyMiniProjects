
const REQUIRE_HTTP = require("http"), REQUIRE_FILE_SYSTEM = require("fs"), REQUIRE_CRAWLER_REQUEST = require(`crawler-request`);

const REQUIRE_CHEERIO = require("cheerio"), REQUIRE_AXIOS = require(`axios`); 

const HTTP_SERVER = REQUIRE_HTTP.createServer(function(Request, Response) 
{ 
    Response.setHeader(`Content-Type`, `text/html`); 
    
    Response.write("Response() "); 
    Response.end(); 

} ); 

function CreateReportPDF() 
{ 
    this.link = ``; 
    this.pdfUrl = ``; 
    this.pdfText = ``; 
    this.date = (new Date()).toISOString(); 
    this.author = ``; 
    this.text = ``; 
    this.title = ``; 
    this.abstract = ``; 
} 

function CreateReport(query) 
{ 
    this.query = query; 
    this.successCount = 0; 
    this.errorMessage = new Array(); 
    this.data = new Array(); 
}

const URL_SITE_PARSE = `https://newjournal.ssmu.kz`; 

var ReportJSON = new CreateReport(URL_SITE_PARSE), ReportJSON_Index = 0; 

(new Promise( function(RESOLVE, REJECT) 
{ 
    RESOLVE(REQUIRE_AXIOS.request( 
        {
            method: "GET",
            url: `${URL_SITE_PARSE}/publication/releases/`,
            headers: {
                "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
            }
        } ) )
} ) ).then(REQUEST_HTML => {
    
    console.log(REQUEST_HTML); 
    return false;

    const CHEERIO_PARSER = REQUIRE_CHEERIO.load(REQUEST_HTML[`data`]); 
    
    CHEERIO_PARSER(`.releases-list`).find(`.release-category`).each((Index, Element) => 
    { 
        if (!((+CHEERIO_PARSER(Element).find(`.release-year h2`).text()) - (new Date()).getFullYear()))
        { 
            CHEERIO_PARSER(Element).find(`.release-item a`).each(function (Index, Element) 
            { 
                if (!(Index%2 - 1)) 
                { 
                    // Link Reports 
                    (new Promise( function(RESOLVE, REJECT) 
                    { 
                        RESOLVE(REQUIRE_AXIOS.request( 
                            {
                                method: "GET",
                                url: URL_SITE_PARSE + CHEERIO_PARSER(Element).attr(`href`),
                                headers: {
                                    "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
                                }
                            }))
                    } ) ).then(REQUEST_HTML2 => { 
                        
                        const DIRECTORY_PDF_FILES_LOAD = `Files/Downloads/`, FILE_NAME_PDF = `DownloadFile`;
                    
                        var ArrayPromisesParsingReports = new Array();
                        
                        if (!REQUIRE_FILE_SYSTEM.existsSync(DIRECTORY_PDF_FILES_LOAD))
                            REQUIRE_FILE_SYSTEM.mkdirSync(DIRECTORY_PDF_FILES_LOAD, { recursive: true } ); 

                        const CHEERIO_PARSER2 = REQUIRE_CHEERIO.load(REQUEST_HTML2[`data`]); 
                        if (CHEERIO_PARSER2(`.release-detail`).find(`hr`).length - 1) 
                            CHEERIO_PARSER2(`.row > .col-md-10 > a`).each(function (Index, Element) 
                            { 
                                var ReportPDF_JSON = new CreateReportPDF(); 
                                ReportPDF_JSON[`link`] = URL_SITE_PARSE + CHEERIO_PARSER2(Element).attr(`href`); 

                                ArrayPromisesParsingReports.push( (new Promise( function(RESOLVE, REJECT) 
                                { 
                                    RESOLVE(REQUIRE_AXIOS.request( 
                                        {
                                            method: "GET",
                                            url: ReportPDF_JSON[`link`],
                                            headers: {
                                                "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
                                            }
                                        } ) ); 
                                } ) ).then(REQUEST_HTML3 => { 

                                    const CHEERIO_PARSER3 = REQUIRE_CHEERIO.load(REQUEST_HTML3[`data`]), REPORT_JSON_INDEX = ReportJSON_Index++; 
                                    const REPORT_PDF_JSON_PDF_URL = URL_SITE_PARSE + CHEERIO_PARSER3(CHEERIO_PARSER3(`.links.clearfix > .underlined-link`)[1]).attr(`href`);  

                                    ReportPDF_JSON[`pdfUrl`] = REPORT_PDF_JSON_PDF_URL; 

                                    ReportPDF_JSON[`title`] = CHEERIO_PARSER3(`.publication-title h5`).text();
                                    CHEERIO_PARSER3(`.authors a`).each(function (Index, Element) 
                                    { 
                                        ReportPDF_JSON[`author`] += CHEERIO_PARSER3(Element).text().trim();
                                    } ); 

                                    ReportPDF_JSON[`abstract`] = CHEERIO_PARSER3(`#about > .tabcont`).text().trim(); 
 
                                    REQUIRE_CRAWLER_REQUEST(REPORT_PDF_JSON_PDF_URL).then( RESPONSE_LOAD_DOCUMENT_PDF => 
                                    { 
                                        ReportPDF_JSON[`pdfText`] = RESPONSE_LOAD_DOCUMENT_PDF[`text`].replace(/[\s\n]+/g, ' ');  
                                        console.log(`Parse PDF file with title "${ReportPDF_JSON[`title`]}" file.`);
                                    } ).catch( ERROR => 
                                    { 
                                        ReportPDF_JSON[`pdfText`] = `пустая - pdf`; 
                                        ReportJSON[`errorMessage`].push(`Не удалось спарсить файл "${REPORT_PDF_JSON_PDF_URL}. Ошибка:"`, ERROR); 
                                    } ).finally( function() 
                                    { 
                                        ReportJSON[`data`][REPORT_JSON_INDEX] = ReportPDF_JSON; 
                                    } ); 

                                } ) ); // Push()
                            } ); 
                        else 
                        { 
                            var ReportPDF_JSON = new CreateReportPDF(); 
                            const REPORT_JSON_INDEX = ReportJSON_Index++, REPORT_PDF_JSON_PDF_URL = URL_SITE_PARSE + CHEERIO_PARSER(Element).attr(`href`)[1]; 
                        
                            ReportPDF_JSON[`pdfUrl`] = REPORT_PDF_JSON_PDF_URL;
                            
                            REQUIRE_CRAWLER_REQUEST(REPORT_PDF_JSON_PDF_URL).then( RESPONSE_LOAD_DOCUMENT_PDF => 
                                { 
                                    ReportPDF_JSON[`pdfText`] = RESPONSE_LOAD_DOCUMENT_PDF[`text`].replace(/[\s\n]+/g, ' ');  
                                    console.log(`Parse PDF file from URL "${REPORT_PDF_JSON_PDF_URL}" file.`);
                                } ).catch( ERROR => 
                                { 
                                    ReportPDF_JSON[`pdfText`] = `пустая - pdf`; 
                                    ReportJSON[`errorMessage`].push(`Не удалось спарсить файл "${REPORT_PDF_JSON_PDF_URL}. Ошибка:"`, ERROR); 
                                } ).finally( function() 
                                { 
                                    ReportJSON[`data`][REPORT_JSON_INDEX] = ReportPDF_JSON; 
                                } ); 

                            
                        }

                        Promise.all(ArrayPromisesParsingReports).then(ArrayPromisesParsingReportsResults => 
                        { 
                            ReportJSON[`successCount`] = ReportJSON[`data`][`length`] - ReportJSON[`errorMessage`][`length`]; 
                            REQUIRE_FILE_SYSTEM.createWriteStream(DIRECTORY_PDF_FILES_LOAD + `DataParsing3.json`, { flags: 'w' } ).end(JSON.stringify(ReportJSON)); 
                        } ).then(function() 
                        { 
                            console.log(`End Part Load`);
                        } )

                    });
                }
            } ); 
            
    
            //ReportJSON[`data`].push(ReportPDF_JSON); 
            //ReportJSON[`successCount`]++;

            return false
        }
    } ); 
    
}).catch(REQUEST_ERROR => {
    console.log(REQUEST_ERROR)
})

HTTP_SERVER.listen(1024, "localhost", function(Error) 
{ 
    console.log( ( Error ? Error : `Listen localhost:1024 ` ) ); 
} ); 
