$(document).ready(function () {


});

function initialCrudDatatable(dataTable) {

    //var table = $('.panel-data .table').DataTable();
    //var dataTable = $('.panel-data .table').DataTable({
    //    serverSide: true,
    //    ajax: {
    //        url: '/Home/Index',
    //        type: 'POST'
    //    }
    //});

    //dataTable.on('order.dt search.dt', function () {
    //    dataTable.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
    //        cell.innerHTML = i + 1;
    //    });
    //}).draw();

    $('.table', '.panel-data').on('click', 'tr', function () {

        var btncreate = $('.crudcreate', '.panel-data .table');
        var btnedit = $('.crudedit', '.panel-data .table');
        var btndelete = $('.cruddelete', '.panel-data .table');



        btnedit.addClass('disabled');
        btndelete.addClass('disabled');


        if ($(this).hasClass('selected')) {
            $(this).removeClass('selected');
        }
        else {
            dataTable.$('tr.selected').removeClass('selected');
            $(this).addClass('selected');
            btnedit.removeClass('disabled');
            btndelete.removeClass('disabled');

            //selectedrowid = $('.rowId', '.panel-data .table .selected').html();                    
        }
    });
}

