import React, {useEffect, useState} from 'react';
import {
  Chart as ChartJS,
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend,
} from 'chart.js';
import { Line } from 'react-chartjs-2';
import faker from 'faker';

ChartJS.register(
  CategoryScale,
  LinearScale,
  PointElement,
  LineElement,
  Title,
  Tooltip,
  Legend
);

export const options = {
  responsive: true,
  plugins: {
    legend: {
      position: 'top',
    },
    title: {
      display: true,
      text: 'Chart.js Line Chart',
    },
  },
};


const dataSet1 = [
  { year: 2010, count: 10, uuu: 3 },
  { year: 2011, count: 20, uuu: 3 },
  { year: 2012, count: 15, uuu: 3 },
  { year: 2013, count: 25, uuu: 3 },
  { year: 2014, count: 22, uuu: 3 },
  { year: 2015, count: 30, uuu: 3 },
  { year: 2016, count: 28, uuu: 3 },
  { year: 2015, count: 18, uuu: 3 },
  { year: 2016, count: 25, uuu: 3 },
];

export default function ChartForm() {

  const [tempData, setTempData] = useState();

    async function isAuthenticated() {
      var url = 'api/SensorData/GetSensorDataList';
      const response = await fetch(url);
      const data = await response.json();

      console.log("dss:");                    
      console.log(dataSet1);   

      console.log("dd:");                    
      console.log(data);   

      setTempData(data);

      console.log("ddstate:");                    
      console.log(tempData);  
    }

    useEffect( () => {isAuthenticated()}, [])

  const labels = tempData?.map(({ date }) => date);
  // const labels = dataSet1.map(({ year }) => year);

  const data = {
    labels,
    datasets: [
      {
        label: 'Dataset 1',
        data: tempData?.map(({ temperature }) => temperature),
        // data: dataSet1.map(({ count }) => count),
        borderColor: 'rgb(255, 99, 132)',
        backgroundColor: 'rgba(255, 99, 132, 0.5)',
      },
    ],
  };

  return <Line options={options} data={data} />;
}
