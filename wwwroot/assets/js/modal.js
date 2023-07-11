function Edit(event) {
  var lineTable = $(event).closest("tr");

  var id = lineTable.find("td:eq(0)").text().trim();
  var title = lineTable.find("td:eq(1)").text().trim();
  var resume = lineTable.find("td:eq(3)").text().trim();
  var content = lineTable.find("td:eq(5)").text().trim();
  // var status = lineTable.find("td:eq(7)").text().trim();

  $("#id").val(id);
  $("#title").val(title);
  $("#resume").val(resume);
  $("#content").val(content);
}

function Delete(event) {
  var lineTable = $(event).closest("tr");

  var id = lineTable.find("td:eq(0)").text().trim();
  var title = lineTable.find("td:eq(1)").text().trim();
  var resume = lineTable.find("td:eq(3)").text().trim();
  var content = lineTable.find("td:eq(5)").text().trim();
  var image = lineTable.find("td:eq(6)").text().trim();

  let data = CreateElement(id);
  let url = "/Admin/DeletePost";

  $.post(url, data, function (resp) {
      $('[message]').html("Post deletado com sucesso");
      $('[messageAlert]').addClass("show");
      $('#messageStatus').show();
      $(event).parent().parent().remove();
      setTimeout(function () {
          $('#messageStatus').hide();
      }, 3500);
  }).fail(function (error) {
      $('[messageAlert]').removeClass("alert-success").addClass("alert-warning").addClass("show");
      $('[message]').html("Erro ao editar" + error.responseText)
      $('#messageStatus').show();
      setTimeout(function () {
          $('#messageStatus').hide();
      }, 3500);
  });
}

function CreateElement(id) {
  return {
      Id: id,
      Image: $("#image").val(),
      Title: $("#title").val(),
      Resume: $("#resume").val(),
      Content: $("#content").val()
  };
}