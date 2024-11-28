var REQUIRE_HTTP = require("http"), REQUIRE_FILE_SYSTEM = require("fs"), REQUIRE_CRAWLER_REQUEST = require("crawler-request");
var REQUIRE_CHEERIO = require("cheerio"), REQUIRE_AXIOS = require("axios");
var HTTP_SERVER = REQUIRE_HTTP.createServer(function (Request, Response) {
    Response.setHeader("Content-Type", "text/html");
    Response.write("Response() ");
    Response.end();
});
var ClassReportPDF = /** @class */ (function () {
    function ClassReportPDF() {
        this["link"] = "";
        this["pdfUrl"] = "";
        this["pdfText"] = "";
        this["date"] = (new Date()).toISOString();
        this["author"] = "";
        this["text"] = "";
        this["title"] = "";
        this["abstract"] = "";
    }
    return ClassReportPDF;
}());
var ClassReport = /** @class */ (function () {
    function ClassReport(query) {
        this["query"] = query;
        this["successCount"] = 0;
        this["errorMessage"] = new Array();
        this["data"] = new Array();
    }
    return ClassReport;
}());
var URL_SITE_PARSE = "https://newjournal.ssmu.kz";
var ReportJSON = new ClassReport(URL_SITE_PARSE), ReportJSON_Index = 0;
(new Promise(function (RESOLVE, REJECT) {
    RESOLVE(REQUIRE_AXIOS.request({
        method: "GET",
        url: "".concat(URL_SITE_PARSE, "/publication/releases/"),
        headers: {
            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
        }
    }));
})).then(function (REQUEST_HTML) {
    var CHEERIO_PARSER = REQUIRE_CHEERIO.load(REQUEST_HTML["data"]);
    CHEERIO_PARSER(".releases-list").find(".release-category").each(function (INDEX, TAG_ELEMENT) {
        if (!((+CHEERIO_PARSER(TAG_ELEMENT).find(".release-year h2").text()) - (new Date()).getFullYear())) {
            CHEERIO_PARSER(TAG_ELEMENT).find(".release-item a").each(function (INDEX, TAG_ELEMENT) {
                if (!(INDEX % 2 - 1)) {
                    // Link Reports 
                    (new Promise(function (RESOLVE, REJECT) {
                        RESOLVE(REQUIRE_AXIOS.request({
                            method: "GET",
                            url: URL_SITE_PARSE + CHEERIO_PARSER(TAG_ELEMENT).attr("href"),
                            headers: {
                                "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
                            }
                        }));
                    })).then(function (REQUEST_HTML2) {
                        var DIRECTORY_PDF_FILES_LOAD = "Files/Downloads/", FILE_NAME_PDF = "DownloadFile";
                        var ArrayPromisesParsingReports = new Array();
                        if (!REQUIRE_FILE_SYSTEM.existsSync(DIRECTORY_PDF_FILES_LOAD))
                            REQUIRE_FILE_SYSTEM.mkdirSync(DIRECTORY_PDF_FILES_LOAD, { recursive: true });
                        var CHEERIO_PARSER2 = REQUIRE_CHEERIO.load(REQUEST_HTML2["data"]);
                        if (CHEERIO_PARSER2(".release-detail").find("hr").length - 1)
                            CHEERIO_PARSER2(".row > .col-md-10 > a").each(function (INDEX, TAG_ELEMENT) {
                                var ReportPDF_JSON = new ClassReportPDF();
                                ReportPDF_JSON["link"] = URL_SITE_PARSE + CHEERIO_PARSER2(TAG_ELEMENT).attr("href");
                                ArrayPromisesParsingReports.push((new Promise(function (RESOLVE, REJECT) {
                                    RESOLVE(REQUIRE_AXIOS.request({
                                        method: "GET",
                                        url: ReportPDF_JSON["link"],
                                        headers: {
                                            "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/108.0.0.0 Safari/537.36"
                                        }
                                    }));
                                })).then(function (REQUEST_HTML3) {
                                    var CHEERIO_PARSER3 = REQUIRE_CHEERIO.load(REQUEST_HTML3["data"]), REPORT_JSON_INDEX = ReportJSON_Index++;
                                    var REPORT_PDF_JSON_PDF_URL = URL_SITE_PARSE + CHEERIO_PARSER3(CHEERIO_PARSER3(".links.clearfix > .underlined-link")[1]).attr("href");
                                    ReportPDF_JSON["pdfUrl"] = REPORT_PDF_JSON_PDF_URL;
                                    ReportPDF_JSON["title"] = CHEERIO_PARSER3(".publication-title h5").text();
                                    CHEERIO_PARSER3(".authors a").each(function (INDEX, TAG_ELEMENT) {
                                        ReportPDF_JSON["author"] += CHEERIO_PARSER3(TAG_ELEMENT).text().trim();
                                    });
                                    ReportPDF_JSON["abstract"] = CHEERIO_PARSER3("#about > .tabcont").text().trim();
                                    REQUIRE_CRAWLER_REQUEST(REPORT_PDF_JSON_PDF_URL).then(function (RESPONSE_LOAD_DOCUMENT_PDF) {
                                        ReportPDF_JSON["pdfText"] = RESPONSE_LOAD_DOCUMENT_PDF["text"].replace(/[\s\n]+/g, ' ').trim();
                                        console.log("Parse PDF file with title \"".concat(ReportPDF_JSON["title"], "\" file."));
                                    }).catch(function (ERROR) {
                                        ReportPDF_JSON["pdfText"] = "\u043F\u0443\u0441\u0442\u0430\u044F - pdf";
                                        ReportJSON["errorMessage"].push("\u041D\u0435 \u0443\u0434\u0430\u043B\u043E\u0441\u044C \u0441\u043F\u0430\u0440\u0441\u0438\u0442\u044C \u0444\u0430\u0439\u043B \"".concat(REPORT_PDF_JSON_PDF_URL, ". \u041E\u0448\u0438\u0431\u043A\u0430:\""), ERROR);
                                    }).finally(function () {
                                        ReportJSON["data"][REPORT_JSON_INDEX] = ReportPDF_JSON;
                                    });
                                })); // Push()
                            });
                        else {
                            var ReportPDF_JSON = new ClassReportPDF();
                            var REPORT_JSON_INDEX_1 = ReportJSON_Index++, REPORT_PDF_JSON_PDF_URL_1 = URL_SITE_PARSE + CHEERIO_PARSER(Element).attr("href")[1];
                            ReportPDF_JSON["pdfUrl"] = REPORT_PDF_JSON_PDF_URL_1;
                            REQUIRE_CRAWLER_REQUEST(REPORT_PDF_JSON_PDF_URL_1).then(function (RESPONSE_LOAD_DOCUMENT_PDF) {
                                ReportPDF_JSON["pdfText"] = RESPONSE_LOAD_DOCUMENT_PDF["text"].replace(/[\s\n]+/g, ' ').trim();
                                console.log("Parse PDF file from URL \"".concat(REPORT_PDF_JSON_PDF_URL_1, "\" file."));
                            }).catch(function (ERROR) {
                                ReportPDF_JSON["pdfText"] = "\u043F\u0443\u0441\u0442\u0430\u044F - pdf";
                                ReportJSON["errorMessage"].push("\u041D\u0435 \u0443\u0434\u0430\u043B\u043E\u0441\u044C \u0441\u043F\u0430\u0440\u0441\u0438\u0442\u044C \u0444\u0430\u0439\u043B \"".concat(REPORT_PDF_JSON_PDF_URL_1, ". \u041E\u0448\u0438\u0431\u043A\u0430:\""), ERROR);
                            }).finally(function () {
                                ReportJSON["data"][REPORT_JSON_INDEX_1] = ReportPDF_JSON;
                            });
                        }
                        (new Promise(function (RESOLVE, REJECT) {
                            setTimeout(function () { return RESOLVE(false); }, 60 * 1000);
                        }).then(function () {
                            return Promise.all(ArrayPromisesParsingReports).then(function (ArrayPromisesParsingReportsResults) {
                                ReportJSON["successCount"] = ReportJSON["data"]["length"] - ReportJSON["errorMessage"]["length"];
                                REQUIRE_FILE_SYSTEM.createWriteStream(DIRECTORY_PDF_FILES_LOAD + "DataParsing.json", { flags: 'w' }).end(JSON.stringify(ReportJSON));
                            }).then(function () {
                                console.log("End Part Load");
                            });
                        }));
                    });
                }
            });
            return false;
        }
    });
}).catch(function (REQUEST_ERROR) {
    console.log(REQUEST_ERROR);
});
HTTP_SERVER.listen(1024, "localhost", function (Error) {
    console.log((Error ? Error : "Listen localhost:1024 "));
});
