// Write your Javascript code.
function searchClick() {
    var text = $('#search_box').val();

    $.ajax({
        type: "GET",
    dataType: "text",
    cache: false,
    url: "https://api.github.com/users/rzaracota/repos",
    success: function (xml) {
        $('#debug_result').html("<pre>" + xml + "</pre>");

    var repos = JSON.parse(xml);

      var list = "<ul>\n";

      for (repo in repos) {
        if (text == "" || repos[repo].name.toLowerCase().indexOf(text.toLowerCase()) != -1) {
            list += "<li>" + repos[repo].name + "</li>";
        }
      }

      list += "</ul>";

      $('#med_list').html(list);
    },
    error: function (xml) {
        alert("Error" + xml);
    }
  });
}

function searchPatients() {
    var text = $('#search_box').val();

    var patients = $('patient_card')

    for (e in patients) {
        if (patients.)
    }
}

function createPatientList(xml) {
    var repos = JSON.parse(xml);

    list ++
}

$(document).ready(function () {
        $('#search_button').on("click", searchClick);
    $(document).keypress(function (e) {
    if (e.which == 13) {
        // enter
        searchClick();
    }
  })

  $('#debug_result').html("Retrieving data...");

  $.ajax({
        type: "GET",
    dataType: "text",
    cache: false,
    url: "https://api.github.com/users/rzaracota/repos",
    success: function (xml) {
        $('#debug_result').html("<pre>" + xml + "</pre>");

        list = createPatientList(xml);

      $('#med_list').html(list);
    },
    error: function (xml) {
        alert("Error" + xml);
    }
  });
});
