(function ($) {
    var _sMUserService = abp.services.app.sMUser,
        l = abp.localization.getSource('SystemManage'),
        _$modal = $('#SMUserCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#SMUsersTable');

    var _$sMUsersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#SMUsersSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;


            abp.ui.setBusy(_$table);
            _sMUserService.getAll(filter).done(function (result) {
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
                action: () => _$sMUsersTable.draw(false)
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
                data: 'userAccount',
                sortable: false
            },
            {
                targets: 2,
                data: 'email',
                sortable: false
            },
            {
                targets: 3,
                data: 'creationTime',
                sortable: false
            },
            {
                targets: 4,
                data: 'creatorUserId',
                sortable: false
            },
            {
                targets: 5,
                data: 'lastModificationTime',
                sortable: false
            },
            {
                targets: 6,
                data: 'lastModifierUserId',
                sortable: false
            },
            {
                targets: 7,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-s-m-user" data-s-m-user-id="${row.id}" data-toggle="modal" data-target="#SMUserEditModal">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger edit-s-m-user delete-s-m-user" data-s-m-user-id="${row.id}" data-s-m-user-name="${row.name}">`,
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

        var sMUser = _$form.serializeFormToObject();
        sMUser.grantedPermissions = [];
        var _$permissionCheckboxes = $("input[name='permission']:checked");
        if (_$permissionCheckboxes) {
            for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                sMUser.grantedPermissions.push(_$permissionCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _sMUserService
            .create(sMUser)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$sMUsersTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-s-m-user', function () {
        var sMUserId = $(this).attr("data-s-m-user-id");
        var sMUserName = $(this).attr('data-s-m-user-name');

        deleteSMUser(sMUserId, sMUserName);
    });

    $(document).on('click', '.edit-s-m-user', function (e) {
        var sMUserId = $(this).attr("data-s-m-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'SMUsers/EditModal?Id=' + sMUserId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#SMUserEditModal div.modal-content').html(content); 
            },
            error: function (e) { }
        })
    });

    abp.event.on('sMUser.edited', (data) => {
        _$sMUsersTable.ajax.reload();
    });

    function deleteSMUser(sMUserId, sMUserName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                sMUserName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _sMUserService.delete({
                        id: sMUserId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$sMUsersTable.ajax.reload();
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
        _$sMUsersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$sMUsersTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
