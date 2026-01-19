
//$(function () {
//    loadTeachers();
//});

//$(document).on("click", "#btnAddTeacher", function () {
//    $.get("/Teacher/LoadForm", function (html) {
//        $("#teacherModalBody").html(html);
//        loadSubjectDropdown();
//        $("#teacherModal").modal("show");
//    });
//});

//function loadTeachers() {
//    $.ajax({
//        url: "/Teacher/LoadTeachers",
//        type: "GET",
//        success: function (html) {
//            $("#teacherTableContainer").html(html);
//        },
//        error: function () {
//            alert("Error loading teachers.");
//        }
//    });
//}

//$(document).on("click", "#btnSaveTeacher", function () {

//    if ($(this).prop('disabled')) {
//        return false;
//    }

//    let formData = {
//        Id: $("#hiddenTeacherId").val(),
//        Name: $("input[name='Name']").val(),
//        Email: $("input[name='Email']").val(),
//        SubjectId: $("#ddlSubject").val()
//    };

//    var $btn = $(this);
//    $btn.prop('disabled', true);

//    $.ajax({
//        url: "/Teacher/AddTeacher",
//        type: "POST",
//        data: formData,
//        success: function () {
//            $("#teacherModal").modal("hide");
//            loadTeachers();
//            $btn.prop('disabled', false);
//        },
//        error: function () {
//            alert("Teacher save failed");
//            $btn.prop('disabled', false);
//        }
//    });
//});

//function loadSubjectDropdown() {
//    $.get("/Subject/GetSubjects", function (data) {
//        var ddl = $("#ddlSubject");
//        ddl.empty();
//        ddl.append('<option value="">Select Subject</option>');
//        $.each(data, function (index, item) {
//            ddl.append(
//                '<option value="' + item.id + '">' + item.name + '</option>'
//            );
//        });
//    });
//}

//$(document).on("click", ".btn-edit", function () {
//    let id = $(this).data("id");
//    $.get("/Teacher/LoadEditForm?id=" + id, function (html) {
//        $("#teacherModalBody").html(html);
//        loadSubjectDropdown();
//        $("#teacherModal").modal("show");
//    });
//});

//$(document).on("click", ".btn-teacher-delete", function () {
//    var id = $(this).data("id");
//    $.ajax({
//        url: "/Teacher/Delete",
//        type: "POST",
//        data: { id: id },
//        success: function () {
//            loadTeachers();
//        }
//    });
//});
