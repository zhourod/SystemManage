(function ($) {
    var _tMTaskService = abp.services.app.tMTask,
        l = abp.localization.getSource('SystemManage'),
        _$modal = $('#TMTaskCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#TMTasksTable');

    var _$tMTasksTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#TMTasksSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;
            filter.state = filter.state > 0 ? filter.state : null


            abp.ui.setBusy(_$table);
            _tMTaskService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$tMTasksTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'state',
                sortable: false,
                render: (data, type, row) => {
                    if (data === 1) {
                        return `<label for="State">${l("Active")}</label>`;
                    } else {
                        if (data === 2) {
                            return `<label for="State">${l("Completed")}</label>`;
                        } else {
                            return `<label for="State">${l("Inactive")}</label>`;
                        }
                    }
                },
            },
            {
                targets: 2,
                data: 'description',
                sortable: false
            },
            {
                targets: 3,
                data: 'assignedPersonName',
                sortable: false
            },
            {
                targets: 4,
                data: 'creationTime',
                sortable: false
            },
            {
                targets: 5,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-t-m-task" data-t-m-task-id="${row.id}" data-toggle="modal" data-target="#TMTaskEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger edit-t-m-task delete-t-m-task" data-t-m-task-id="${row.id}" data-t-m-task-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>',
                    ].join('');
                }
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var tMTask = _$form.serializeFormToObject();
        
        //tMTask.grantedPermissions = [];
        tMTask.assignedPersonId = "";
        //var _$permissionCheckboxes = $("input[name='permission']:checked");
        var _$personRadios = $("input[name = 'person']:checked");
        if (_$personRadios) {
            for (var personIndex = 0; personIndex < _$personRadios.length; personIndex++) {
                var _$personRadio = $(_$personRadios[personIndex]);
                //tMTask.grantedPermissions.push(_$personRadio.val());
                //tMTask = _$personRadio.val()
                tMTask.assignedPersonId = _$personRadio.val()
            }
        }

        abp.ui.setBusy(_$modal);
        _tMTaskService
            .create(tMTask)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$tMTasksTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-t-m-task', function () {
        var tMTaskId = $(this).attr("data-t-m-task-id");
        var tMTaskName = $(this).attr('data-t-m-task-name');

        deleteTMTask(tMTaskId, tMTaskName);
    });

    $(document).on('click', '.edit-t-m-task', function (e) {
        var tMTaskId = $(this).attr("data-t-m-task-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'TMTasks/EditModal?Id=' + tMTaskId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TMTaskEditModal div.modal-content').html(content); 
            },
            error: function (e) { }
        })
    });

    abp.event.on('tMTask.edited', (data) => {
        _$tMTasksTable.ajax.reload();
    });

    function deleteTMTask(tMTaskId, tMTaskName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                tMTaskName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _tMTaskService.delete({
                        id: tMTaskId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$tMTasksTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$tMTasksTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$tMTasksTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
