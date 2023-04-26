/*! * jQuery Cookie Plugin v1.4.1
 * https://github.com/carhartl/jquery-cookie
 */

!(function (a) {
  "function" == typeof define && define.amd
    ? define(["jquery"], a)
    : "object" == typeof exports
    ? a(require("jquery"))
    : a(jQuery);
})(function (a) {
  function c(a) {
    return h.raw ? a : encodeURIComponent(a);
  }
  function d(a) {
    return h.raw ? a : decodeURIComponent(a);
  }
  function e(a) {
    return c(h.json ? JSON.stringify(a) : String(a));
  }
  function f(a) {
    0 === a.indexOf('"') &&
      (a = a.slice(1, -1).replace(/\\"/g, '"').replace(/\\\\/g, "\\"));
    try {
      return (
        (a = decodeURIComponent(a.replace(b, " "))), h.json ? JSON.parse(a) : a
      );
    } catch (c) {}
  }
  function g(b, c) {
    var d = h.raw ? b : f(b);
    return a.isFunction(c) ? c(d) : d;
  }
  var b = /\+/g,
    h = (a.cookie = function (b, f, i) {
      if (arguments.length > 1 && !a.isFunction(f)) {
        if (((i = a.extend({}, h.defaults, i)), "number" == typeof i.expires)) {
          var j = i.expires,
            k = (i.expires = new Date());
          k.setTime(+k + 864e5 * j);
        }
        return (document.cookie = [
          c(b),
          "=",
          e(f),
          i.expires ? "; expires=" + i.expires.toUTCString() : "",
          i.path ? "; path=" + i.path : "",
          i.domain ? "; domain=" + i.domain : "",
          i.secure ? "; secure" : "",
        ].join(""));
      }
      for (
        var l = b ? void 0 : {},
          m = document.cookie ? document.cookie.split("; ") : [],
          n = 0,
          o = m.length;
        o > n;
        n++
      ) {
        var p = m[n].split("="),
          q = d(p.shift()),
          r = p.join("=");
        if (b && b === q) {
          l = g(r, f);
          break;
        }
        b || void 0 === (r = g(r)) || (l[q] = r);
      }
      return l;
    });
  (h.defaults = {}),
    (a.removeCookie = function (b, c) {
      return void 0 === a.cookie(b)
        ? !1
        : (a.cookie(b, "", a.extend({}, c, { expires: -1 })), !a.cookie(b));
    });
});

/*

Qwilo - Multipurpose Responsive HTML5 Template
Author: iqonicthemes.in
Version: 1.0
Design and Developed by: iqonicthemes.in

*/

jQuery(document).ready(function ($) {
  /*************************
       			Right sidebar
		*************************/
  (style_switcher = $(".iq-colorbox")),
    (panelWidth = style_switcher.outerWidth(true));
  $(".iq-colorbox .color-full").on("click", function () {
    var $this = $(this);
    if ($(".iq-colorbox.color-fix").length > 0) {
      style_switcher.animate({ right: "0px" });
      $(".iq-colorbox.color-fix").removeClass("color-fix");
      $(".iq-colorbox").addClass("opened");
    } else {
      $(".iq-colorbox.opened").removeClass("opened");
      $(".iq-colorbox").addClass("color-fix");
      style_switcher.animate({ right: "-" + panelWidth });
    }
    return false;
  });

  /*************************
       		 style change 
		*************************/
  var link = $('link[data-style="styles"]'),
    link_no_cookie = $('link[data-style="styles-no-cookie"]');

  /*************************
       		 Color Changer
		*************************/
  $(".iq-colorbox .iq-colorselect li").on("click", function () {
    var $this = $(this),
      tp_stylesheet = $this.data("style");
    iq_color = $this.css("background-color");
    $(".iq-colorbox .iq-colorselect .iq-colormark").removeClass("iq-colormark");
    $this.addClass("iq-colormark");
    var str = iq_color;
    var res = str.replace("rgb(", "");
    var res1 = res.replace(")", "");
    iq_color2 = "rgba(" + res1.concat(",", 0.1) + ")";
    iq_color3 = "rgba(" + res1.concat(",", 0.8) + ")";
    document.documentElement.style.setProperty("--iq-primary", iq_color);
    document.documentElement.style.setProperty("--iq-light-primary", iq_color2);
    document.documentElement.style.setProperty("--iq-primary-hover", iq_color3);
  });
});
