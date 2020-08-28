//Light and Dark theme script
const toggleSwitch = document.querySelector('.theme-switch input[type="checkbox"]');

const currentTheme = localStorage.getItem('theme') || null;

if (currentTheme) {
	document.documentElement.setAttribute('data-theme', currentTheme);

	if (currentTheme === 'dark') {
		toggleSwitch.checked = true;
	}
}

function switchTheme(e) {
	if (e.target.checked) {
		document.documentElement.setAttribute('data-theme', 'dark');
		localStorage.setItem('theme', 'dark');
	}
	else {
		document.documentElement.setAttribute('data-theme', 'light');
		localStorage.setItem('theme', 'light');
	}
}

toggleSwitch.addEventListener('change', switchTheme, false);


// Table Slide
$(function () {
	$("tr.hidden-row").find("div.details").hide();
	$("tr.expander-row").click(function (event) {
		event.stopPropagation();
		var $target = $(event.target);
		if ($target.closest("td").attr("colspan") > 1) {
			$target.slideUp();
		}
		else {
			$target.closest("tr").next().find("div.details").slideToggle();
		}
	});
});

// Cascading Dropdowns
$(function () {
	$("#MakeID").on("change", function () {
		var makeID = $(this).val();
		$("#ModelID").empty();
		$("#TrimID").empty();
		$("#Price").val(0);
		$("#ModelID").append("<option value=''>--Select Model--</option>");
		$("#TrimID").append("<option value=''>--Select Trim Level--</option>");
		$.getJSON(`?handler=Models&makeID=${makeID}`, (data) => {
			$.each(data, function (i, item) {
				$("#ModelID").append(`<option value="${item.id}">${item.name}</option>`);
			});
		});
	});

	$("#ModelID").on("change", function () {
		var modelID = $(this).val();
		$("#TrimID").empty();
		$("#Price").val(0);
		$("#TrimID").append("<option value=''>--Select Trim Level--</option>");
		$.getJSON(`?handler=Trims&modelID=${modelID}`, (data) => {
			$.each(data, function (i, item) {
				$("#TrimID").append(`<option value="${item.id}">${item.name}</option>`);
			});
		});
	});

	$("#TrimID").on("change", function () {
		var trimID = $(this).val();
		$.getJSON(`?handler=Price&trimID=${trimID}`, (data) => {
			$("#Price").val(data);
		});
	});

});

