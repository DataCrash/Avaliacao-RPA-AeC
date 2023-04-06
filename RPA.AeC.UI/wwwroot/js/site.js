$(document).ready(function () {
    $('#btnSearch').on('click', function () {
        if ($('#searchText').val()) {
            $('#retorno').html('<div id="loading" style="align-content-center  align-items-center"><img src="images/loading.gif" width="10%" /></br><img src="images/robotWorking.gif" width="50%"></div>');

            $.get({
                url: 'https://localhost:7039/api/SearchedResult/' + $('#searchText').val(),
                data: $('#formSerch').serialize(),
                success: function (data) {
                    $('#loading').remove();
                    $('#retorno').html(TableBuilder(data));
                },
                error: function (data) {
                    $('#loading').remove();
                    console.warn(data);
                },
                dataType: 'json'
            });
        } else {
            alert('É necessário preencher o termo a ser pesquisado!');
        };
    });
})

function TableBuilder(data) {
    let tableOutput = `
        <table class="table table-bordered table-striped" id = "Tabela">
            <thead>
                <tr>
                    <th>Titulo</th>
                    <th>Área</th>
                    <th>Autor</th>
                    <th>Data de Publicação</th>
                    <th>Descrição</th>
                </tr>
            </thead>
            <tbody>
    `;

    for (let result in data) {
        tableOutput += `
            <tr class="odd gradeA">
                <td>${data[result].title}</td>
                <td>${data[result].area}</td>
                <td>${data[result].author}</td>
                <td>${data[result].publishDate)}</td>
                <td>${data[result].description}</td>
            </tr>`;
    }
    tableOutput += `
            </tbody>
        </table>`;

    return tableOutput;
}