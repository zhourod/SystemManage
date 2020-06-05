(function ($) {
    var _tMTaskService = abp.services.app.tMTask,
        l = abp.localization.getSource('SystemManage'),
        _$modal = $('#TMTaskEditModal'),
        _$form = $('form[name = TMTaskEditForm]');

     function save() {
         if (!_$form.valid()) {
             return;
        }
         var tMTask = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
         abp.ui.setBusy(_$form);
         _tMTaskService.update(tMTask).done(function () {
                 _$modal.modal('hide');
                 //location.reload(true); //reload page to see edited tMTask!
             abp.notify.info(l('SavedSuccessfully'));
             abp.event.trigger('tMTask.edited', tMTask);
        }).always(function () {
                 abp.ui.clearBusy(_$modal);
        });
    }
     //Handle save button click
     _$form.closest('div.modal-content').find(".save-button").click(function (e) {
         e.preventDefault();
         save();
    });
     //Handle enter key
     _$form.find('input').on('keypress', function (e) {
         if (e.which === 13) {
             e.preventDefault();
             save();
        }
    });
     $.AdminBSB.input.activate(_$form);
     _$modal.on('shown.bs.modal', function () {
         _$form.find('input[type = text]: first').focus();
    });
})(jQuery);