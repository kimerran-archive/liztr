var w2p = (function (_) {
        return {
            p: function (c, a, m, cb) {
                _.ajax({
                    url: "/" + c + "/" + a,
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(m),
                    success: function (r) {                       
                        cb({successful: r.s, result: r});
                    },
                    error: function (r) {
                        console.log("%O", r);
                    }
                });
            },
            m: function (res) {
                var m = { Url: res.result.u, Wattcode: res.result.w, Title: res.result.t };
                return m;
            }
        }
}($));
//var w2p = (function (jq) {
//    return {
//        p: function (c, a, m, cb) {
//            var ret;
//            jq.ajax({
//                url: "/" + c + "/" + a,
//                type: "POST",
//                contentType: "application/json",
//                data: JSON.stringify(m),
//                success: function (r) {
//                    ret = {
//                        successful: true,
//                        result: r
//                    };
//                    cb(ret);
//                },
//                error: function (r) {
//                    ret = {
//                        successful: false,
//                        result: r
//                    };
//                    cb(ret);
//                }
//            });
//        }
//    }
//}($));