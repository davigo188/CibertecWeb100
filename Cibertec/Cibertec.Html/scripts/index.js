(function (cibertec) {
    cibertec.Index = {
        currentYear: function () {
            var today = new Date();
            return today.getFullYear();
        },

        currentMonth: function () {
            var today = new Date();
            return length(today.getMonth());
        }
    };
    document.getElementById("date").innerHTML = cibertec.Index.currentYear() + ' ' + cibertec.Index.currentMonth();
})(window.cibertec = window.cibertec || {});