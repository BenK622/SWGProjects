tinymce.init({
    selector: "textarea",
    plugins: "image imagetools link spellchecker",
    browser_spellcheck: true,
    contextmenu: false,
    //onchange_callback: function (editor) {
    //    tinyMCE.triggerSave();
    //    $("#mytextarea").valid();
    //}
});
//$(function() {
//    var validator = $("#blogForm")
//        .submit(function() {
//            // update underlying textarea before submit validation
//            tinyMCE.triggerSave();
//        })
//        .validate({
//            ignore: "",
//            rules: {
//                content: "required"
//            },
//            errorPlacement: function(label, element) {
//                // position error label after generated textarea
//                if (element.is("textarea")) {
//                    label.insertAfter(element.next());
//                } else {
//                    label.insertAfter(element)
//                }
//            }
//        });
//    validator.focusInvalid = function() {
//        // put focus on tinymce on submit validation
//        if (this.settings.focusInvalid) {
//            try {
//                var toFocus = $(this.findLastActive() || this.errorList.length && this.errorList[0].element || []);
//                if (toFocus.is("textarea")) {
//                    tinyMCE.get(toFocus.attr("id")).focus();
//                } else {
//                    toFocus.filter(":visible").focus();
//                }
//            } catch (e) {
//                // ignore IE throwing errors when focusing hidden elements
//            }
//        }
//    }
//});