
const REQUIRE_HTTP = require("http"), REQUIRE_HTTPS = require("https"), REQUIRE_FILE_STREAM = require("fs"); 

const REQUIRE_PDF_PARSE = require(`pdf-parse`); 

const REQUIRE_CHEERIO = require("cheerio"), REQUIRE_AXIOS = require("axios");

const HTTP_SERVER = REQUIRE_HTTP.createServer(function(Request, Response) 
{ 
    Response.setHeader(`Content-Type`, `text/html`); 
    /*FILE_STREAM.readFile(`./Main.html`, function(Error, Data) 
    { 
        Error ? console.log(Error) : Response.write(Data); 
        Response.end(); 
    } ); */

    //console.log(Request);
    if (Request.method == `POST` && Request.url == `/ApiSecret/CreateUser/`) 
	{ 
        
		console.log(`Server `, Request.body, Response); 
	} 

    //Response.statusCode = 200; 
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

var ReportJSON = new CreateReport(URL_SITE_PARSE), ArrayPromisesParsingReports = new Array(); 



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
    
    const CHEERIO_PARSER = REQUIRE_CHEERIO.load(REQUEST_HTML[`data`]); 
    
    CHEERIO_PARSER(`.releases-list`).find(`.release-category`).each((Index, Element) => 
    { 
        if (!((+CHEERIO_PARSER(Element).find(`.release-year h2`).text()) - (new Date()).getFullYear()))
        { 
            CHEERIO_PARSER(Element).find(`.release-item a`).each(function (Index, Element) 
            { 
                if (!(Index%2)) 
                { 
                    // Link PDF 
                    //console.log(URL_SITE_PARSE + CHEERIO_PARSER(Element).attr(`href`)); 
                }
                else if (!(Index%2 - 1)) 
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
                        
                        if (!REQUIRE_FILE_STREAM.existsSync(DIRECTORY_PDF_FILES_LOAD))
                            REQUIRE_FILE_STREAM.mkdirSync(DIRECTORY_PDF_FILES_LOAD, { recursive: true } ); 

                        const CHEERIO_PARSER2 = REQUIRE_CHEERIO.load(REQUEST_HTML2[`data`]); 
                        if (CHEERIO_PARSER2(`.release-detail`).find(`hr`).length - 1) 
                        { 
                            CHEERIO_PARSER2(`.col-md-10 > a`).each(function (Index, Element) 
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
                                        }))
                                } ) ).then(REQUEST_HTML3 => { 

                                    const CHEERIO_PARSER3 = REQUIRE_CHEERIO.load(REQUEST_HTML3[`data`]);  

                                    ReportPDF_JSON[`pdfUrl`] = URL_SITE_PARSE + CHEERIO_PARSER3(CHEERIO_PARSER3(`.links.clearfix > .underlined-link`)[1]).attr(`href`); 

                                    ReportPDF_JSON[`title`] = CHEERIO_PARSER3(`.publication-title h5`).text();
                                    CHEERIO_PARSER3(`.authors a`).each(function (Index, Element) 
                                    { 
                                        ReportPDF_JSON[`author`] += CHEERIO_PARSER3(Element).text().trim();
                                    } ); 

                                    ReportPDF_JSON[`abstract`] = CHEERIO_PARSER3(`#about > .tabcont`).text().trim(); 

                                    ReportJSON[`data`].push(ReportPDF_JSON); 

                                } ) ); // Push()


                            } ); 
                            
                        } 
                        else 
                        { 
                            const file = REQUIRE_FILE_STREAM.createWriteStream(DIRECTORY_PDF_FILES_LOAD + FILE_NAME_PDF + `.pdf`);

                            REQUIRE_HTTPS.get(URL_SITE_PARSE + CHEERIO_PARSER3(Element).attr(`href`), Response => {
                                Response.pipe(file);
                                file.on('finish', () => {
                                    file.close(() => {
                                        console.log('File downloaded successfully'); 
                                        ;
                                    });
                                });
                            });
                        } 

                        Promise.all(ArrayPromisesParsingReports).then(ArrayPromisesParsingReportsResults => { 
                            ReportJSON[`data`][`forEach`]( function(ReportPDF_JSON, Index) 
                            { 
                                console.log(ReportPDF_JSON.pdfUrl); 

                                const PATH_TO_DOCUMENT_PDF = `${DIRECTORY_PDF_FILES_LOAD}${FILE_NAME_PDF}${Index}.pdf`;
                                var file = REQUIRE_FILE_STREAM.createWriteStream(PATH_TO_DOCUMENT_PDF);
                                REQUIRE_HTTPS.get(ReportPDF_JSON[`pdfUrl`], (response2) => {
                                    response2.pipe(file)
                                    .on("close", function() 
                                    { 
                                        REQUIRE_PDF_PARSE(REQUIRE_FILE_STREAM.readFileSync(PATH_TO_DOCUMENT_PDF)).then( DOCUMENT_PDF => 
                                        { 
                                            ReportJSON[`data`][Index][`pdfText`] = DOCUMENT_PDF.text.replace(/\s+/g, ' ');  
                                        } ).catch(function(ERROR) 
                                        { 
                                            ReportJSON[`data`][Index][`pdfText`] = `пустая - pdf`; 
                                            ReportJSON[`errorMessage`].push(`Не удалось спарсить файл "${ReportPDF_JSON[`pdfUrl`]}. Ошибка:"`, ERROR); 
                                        } );
                                        
                                        console.log(`Generated PDF file saved as "${PATH_TO_DOCUMENT_PDF}.pdf" file.`);
                                    });
                                });

                                /*REQUIRE_TEXT_RACT.fromUrl(ReportPDF_JSON[`pdfUrl`], { "preserveLineBreaks": true }, function(ERROR, DOCUMENT_PDF_ALL_TEXT) 
                                { 
                                    ReportJSON[`data`][Index][`pdfText`] = DOCUMENT_PDF_ALL_TEXT;
                                    //console.log(ReportPDF_JSON[`pdfUrl`], ERROR, DOCUMENT_PDF_ALL_TEXT);
                                } );*/                                
                                
                                
                                /*(new Promise( function(RESOLVE, REJECT) 
                                { 
                                    RESOLVE(require(`aspose-pdf-js`))
                                    //RESOLVE(REQUIRE_PDF_LIB.PDFDocument.load(REQUIRE_FILE_STREAM.readFileSync(`${DIRECTORY_PDF_FILES_LOAD}${FILE_NAME_PDF}${Index}.pdf`)))
                                } ) ).then(ASPOSE_PDF => { 
                                    const json = ASPOSE_PDF.AsposePdfExtractText(ReportPDF_JSON[`pdfUrl`]);
                                    console.log("AsposePdfExtractText => %O", json.errorCode == 0 ? json.extractText : json.errorText);

                                } ).then(RESPONSE_DOCUMENT_PDF_URL => RESPONSE_DOCUMENT_PDF_URL[`arrayBuffer`]() ).
                                then(RESPONSE_DOCUMENT_PDF_BYTE => REQUIRE_PDF_LIB.PDFDocument.load(RESPONSE_DOCUMENT_PDF_BYTE)).
                                then(DOCUMENT_PDF => { 
                                    
                                    for (const PAGE of DOCUMENT_PDF[`getPages`]()) 
                                        for (const KEY in PAGE) 
                                            console.log(KEY, `->`, PAGE.doc.context.contentStream().getContents().toString())

                                    /const PAGES = DOCUMENT_PDF[`getPages`](); 
                                    console.log(PAGES[0].doc.context.contentStream);
                                    console.log('Form ', );
                                    for (const DOCUMENT_PDF_PAGE of DOCUMENT_PDF.getForm().getFields()) //DOCUMENT_PDF.extractText() 
                                    { 
                                        
                                        console.log('fc',DOCUMENT_PDF_PAGE);
                                    }/
                                } );*/



                                /*const file = REQUIRE_FILE_STREAM.createWriteStream(`${DIRECTORY_PDF_FILES_LOAD}${FILE_NAME_PDF}${Index}.pdf`);

                                REQUIRE_HTTPS.get(ReportPDF_JSON[`pdfUrl`], Response => {
                                    Response.pipe(file);
                                    file.on('finish', () => 
                                        file.close(() => {
                                            console.log('File downloaded successfully'); 
                                            
                                            (new Promise( function(RESOLVE, REJECT) 
                                            { 
                                                RESOLVE(REQUIRE_PDF_LIB.PDFDocument.load(REQUIRE_FILE_STREAM.readFileSync(`${DIRECTORY_PDF_FILES_LOAD}${FILE_NAME_PDF}${Index}.pdf`)))
                                            } ) ).then(DOCUMENT_PDF => { 
                                                console.log('fc',DOCUMENT_PDF.getForm());
                                                for (const DOCUMENT_PDF_PAGE of DOCUMENT_PDF.getForm().getFields()) //DOCUMENT_PDF.extractText() 
                                                { 
                                                    
                                                    console.log('fc',DOCUMENT_PDF_PAGE);
                                                }
                                            } ).then(DOCUMENT_PDF_ALL_TEXT => {

                                                ReportJSON[`data`][Index][`pdfText`] = DOCUMENT_PDF_ALL_TEXT;
                                                console.log(ReportPDF_JSON); 
                                                REQUIRE_FILE_STREAM.unlink(`${DIRECTORY_PDF_FILES_LOAD}${FILE_NAME_PDF}${Index}.pdf`)
                                            } );
                                        } )
                                    ); 
                                } ); */
                                
                            } )
                            
                            /*for (var i = 0; i < REPORT_JSON_DATA_LENGTH; i++) 
                            { 
                                const file = REQUIRE_FILE_STREAM.createWriteStream(DIRECTORY_PDF_FILES_LOAD + FILE_NAME_PDF);

                                    REQUIRE_HTTPS.get(ReportPDF_JSON[`pdfUrl`], Response => {
                                        Response.pipe(file);
                                        file.on('finish', () => 
                                            file.close(() => {
                                                console.log('File downloaded successfully'); 
                                                
                                                (new Promise( function(RESOLVE, REJECT) 
                                                { 
                                                    RESOLVE(REQUIRE_PDF_LIB.PDFDocument.load(REQUIRE_FILE_STREAM.readFileSync(DIRECTORY_PDF_FILES_LOAD + FILE_NAME_PDF)))
                                                } ) ).then(DOCUMENT_PDF => DOCUMENT_PDF.extractText() ).then(DOCUMENT_PDF_ALL_TEXT => {

                                                    ReportPDF_JSON[`pdfText`] = DOCUMENT_PDF_ALL_TEXT;
                                                    console.log(ReportPDF_JSON); 
                                                } );
                                            } )
                                        );
                                    } );
                            }*/

                            ReportJSON[`successCount`] = ReportJSON[`data`][`length`] - ReportJSON[`errorMessage`][`length`]; 
                            var WriterIO_Stream = REQUIRE_FILE_STREAM.createWriteStream(DIRECTORY_PDF_FILES_LOAD + `DataParsing.json`, { flags: 'w' } ); 
                            WriterIO_Stream.end(JSON.stringify(ReportJSON))
                        } )

                        //REQUIRE_FILE_STREAM.unlink(DIRECTORY_PDF_FILES_LOAD + FILE_NAME_PDF);
                    });
                    //ReportPDF_JSON[`pdfUrl`] = URL_SITE_PARSE + CHEERIO_PARSER(Element).attr(`href`); 
                }
            } ); 
            
    
            //ReportJSON[`data`].push(ReportPDF_JSON); 
            //ReportJSON[`successCount`]++;

            return false
        }
    } ); 
    
    
    
    /*let writer = REQUIRE_FILE_STREAM.createWriteStream('test_gfg.txt', {
        flags: 'w'
    }); 

    writer.end(JSON.stringify(ReportJSON))*/
    
    //console.log(CHEERIO_PARSER(`a.release-year > h2`).text()); 
}).catch(REQUEST_ERROR => {
    console.log(REQUEST_ERROR)
})



HTTP_SERVER.listen(1024, "localhost", function(Error) 
{ 
    console.log( ( Error ? Error : `Listen localhost:1024 ` ) ); 
} ); 


