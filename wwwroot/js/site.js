// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ListAllPeople()
{
    $.ajax({
        type: "GET",
        url: "Ajax/GetPeople",
        success: function (peopleList) {
            console.log("GetPeople: peopleList = ", peopleList);
            $("div#peopleList").html(peopleList)
        }
    })
}

function GetDetails() {
    var inputVal = $('input#inputVal').val();
    $.ajax({
        type: "POST",
        url: `Ajax/GetPeople/${inputVal}`,
        success: function (detailsGet) {
            console.log("GetDetails: detailsGet = ", detailsGet);
            console.log(inputVal);
            $("div#peopleList").html(detailsGet)
        }
    })
}

function AnnihilatePerson() {
    var inputVal = $('input#inputVal').val();
    $.ajax({
        type: "POST",
        url: `Ajax/AnnihilatePerson/${inputVal}`,
        success: function (annihilate) {
            console.log("AnnihilatePerson: annihilate = ", annihilate);
            console.log(inputVal);
            $("div#peopleList").html(annihilate)
        }
    })
}
    






