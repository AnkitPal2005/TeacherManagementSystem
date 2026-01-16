$(function () {
    loadSubjects();
    // Add Button Click
    $("#btnAdd").on("click", function () {
        $("#modalTitle").text("Add Subject");
        $.get("/Subject/LoadForm", function (html) {
            $("#modalBody").html(html);
            $("#subjectModal").modal("show");
        });
    });

    // Save Button Click
    $("#btnSave").on("click", function () {
        var id = $("#subjectId").val() || 0;
        var subjectObj = {
            Id: parseInt(id) || 0,
            Name: $("#subjectName").val(),
            Code: $("#subjectCode").val()
        };
        if (!subjectObj.Name.trim() || !subjectObj.Code.toString().trim()) {
            alert("Please fill in all fields.");
            return;
        }
        var url = subjectObj.Id === 0 ? "/Subject/Create" : "/Subject/Edit";
        $.ajax({
            url: url,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(subjectObj),
            success: function () {
                $("#subjectModal").modal("hide");
                loadSubjects();
            },
            error: function () {
                alert("Error saving subject.");
            }
        });
    });
});

// Edit Button Click
$(document).on("click", ".btn-edit", function () {
    var id = $(this).data("id");
    $("#modalTitle").text("Edit Subject");
    $.get("/Subject/EditPartial?id=" + id, function (html) {
        $("#modalBody").html(html);
        $("#subjectModal").modal("show");
    });
});

$(document).on("click", ".btn-delete", function () {
    if (!confirm("Delete this subject?")) return;
    var id = $(this).data("id");
    $.ajax({
        url: "/Subject/Delete",
        type: "POST",
        data: { id: id },
        success: function () {
            loadSubjects();
        }
    })
})

function loadSubjects() {
    $.ajax({
        url: "/Subject/LoadSubjects",
        type: "GET",
        success: function (html) {
            $("#tableContainer").html(html);
        },
        error: function () {
            $("#tableContainer").html("<div class='text-danger'>Failed to load subjects.</div>");
        }
    })
}