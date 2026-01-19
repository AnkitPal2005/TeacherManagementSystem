
//$(function () {
//    loadSubjects();

//    // Add Button Click
//    $("#btnAdd").on("click", function () {
//        $("#modalTitle").text("Add Subject");
//        $.get("/Subject/LoadForm", function (html) {
//            $("#modalBody").html(html);
//            $("#subjectModal").modal("show");
//        });
//    });

//    // Save Button Click - FIX: Check if already saving
//    $(document).off("click", "#btnSave")
//        .on("click", "#btnSave", function () {

//            // Prevent double submission
//            if ($(this).prop('disabled')) {
//                return false;
//            }

//            var id = $("#subjectId").val() || 0;
//            var subjectObj = {
//                Id: parseInt(id) || 0,
//                Name: $("#subjectName").val(),
//                Code: $("#subjectCode").val()
//            };

//            if (!subjectObj.Name.trim() || !subjectObj.Code.toString().trim()) {
//                alert("Please fill in all fields.");
//                return;
//            }

//            var url = subjectObj.Id === 0 ? "/Subject/Create" : "/Subject/Edit";

//            // Disable button to prevent double click
//            var $btn = $(this);
//            $btn.prop('disabled', true).text('Saving...');

//            $.ajax({
//                url: url,
//                type: "POST",
//                data: subjectObj,
//                success: function () {
//                    $("#subjectModal").modal("hide");
//                    loadSubjects();
//                    $btn.prop('disabled', false).text('Save');
//                },
//                error: function () {
//                    alert("Error saving subject.");
//                    $btn.prop('disabled', false).text('Save');
//                }
//            });
//        });
//});

//// Edit Button Click
//$(document).on("click", ".btn-subject-edit", function () {
//    var id = $(this).data("id");
//    $("#modalTitle").text("Edit Subject");
//    $.get("/Subject/EditPartial?id=" + id, function (html) {
//        $("#modalBody").html(html);
//        $("#subjectModal").modal("show");
//    });
//});

//$(document).on("click", ".btn-subject-delete", function () {
//    var id = $(this).data("id");
//    $.ajax({
//        url: "/Subject/Delete",
//        type: "POST",
//        data: { id: id },
//        success: function () {
//            loadSubjects();
//        }
//    });
//});

//function loadSubjects() {
//    $.ajax({
//        url: "/Subject/LoadSubjects",
//        type: "GET",
//        success: function (html) {
//            $("#tableContainer").html(html);
//        },
//        error: function () {
//            $("#tableContainer").html("<div class='text-danger'>Failed to load subjects.</div>");
//        }
//    });
//}


