const ctx = document.getElementById('main_chart');
const label = ["Values"];

const scale = {
	y: {
		grid: {
			color: "#5b5b5b",
			drawTicks: false,
		},
		ticks: {
			display: false,
		},
	},
	x: {
		beginAtZero: true,
		grid: {
			color: "#5b5b5b",
			drawTicks: false,

		},
		ticks: {
			color: "#5b5b5b",
		},
	}
}

new Chart(ctx, {
	type: 'bar',
	data: {
		labels: label,
		datasets: createDatasetCollection(ListOfValues[0], ListOfCounts[0]),
	},
	options: {
		scales: scale,

		plugins: {
			title: {
				display: true,
				text: 'All trends',
				font: {
					size: 24,
					family: 'Arial',
					weight: 'bold',
				},
				color: '#FFFFFF',
				align: 'center',
			}
		},

		indexAxis: 'y',
	}
});

new Chart(document.getElementById('colour_chart'), {
	type: 'bar',
	data: {
		labels: label,
		datasets: createDatasetCollection(ListOfValues[1], ListOfCounts[1]),
	},
	options: {
		scales: scale,

		plugins: {
			title: {
				display: true,
				text: 'Colour trends',
				font: {
					size: 18,
					family: 'Arial',
					weight: 'bold',
				},
				color: '#FFFFFF',
				align: 'center',
			}
		},

		indexAxis: 'y',
	}
});

new Chart(document.getElementById('price_chart'), {
	type: 'bar',
	data: {
		labels: label,
		datasets: createDatasetCollection(ListOfValues[2], ListOfCounts[2]),
	},
	options: {
		scales: scale,

		plugins: {
			title: {
				display: true,
				text: 'Price trends',
				font: {
					size: 18,
					family: 'Arial',
					weight: 'bold',
				},
				color: '#FFFFFF',
				align: 'center',
			}
		},

		indexAxis: 'y',
	}
});

new Chart(document.getElementById('font_chart'), {
	type: 'bar',
	data: {
		labels: label,
		datasets: createDatasetCollection(ListOfValues[3], ListOfCounts[3]),
	},
	options: {
		scales: scale,

		plugins: {
			title: {
				display: true,
				text: 'Font trends',
				font: {
					size: 18,
					family: 'Arial',
					weight: 'bold',
				},
				color: '#FFFFFF',
				align: 'center',
			}
		},

		indexAxis: 'y',
	}
});

function getColor(value) {
	for (let i = 0; i < ListOfValues.length; i++) {
		for (let j = 0; j < ListOfValues[i].length; j++) {
			if (value == ListOfValues[i][j]) {
				if (i == 1) return "rgba(197, 81, 216, 0.9)";
				if (i == 2) return "rgba(240, 45, 17, 0.9)";
				if (i == 3) return "rgba(246, 250, 17, 0.9)";
			}
		}
	}

	return null;
}

function createDatasetCollection(valueList, countList) {
	const dataset = [];
	for (let i = 0; i < valueList.length; i++) {
		dataset.push({
			label: valueList[i],
			data: [countList[i]],
			backgroundColor: getColor(valueList[i])
		});
	}
	return dataset;
}