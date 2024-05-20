import React, { useEffect, useState } from 'react'
import Navbar from '../components/Navbar';

function Student() {
    const [data, setData] = useState([]);
    useEffect(()=>{
        async function fetchData ()
        {
            const result = await fetch('https://localhost:5001/Student/GetStudents');
            const json = await result.json();
            setData(json);
        }

        fetchData();

    },[]);

    const addStudent = () =>{
        useEffect(()=>{
            async function addData ()
            {
                const result = await fetch(`https://localhost:5001/Student/AddStudent`);
                const json = await result.json();
                setData(json);
            }
    
            addData();
    
        },[]);
    }
  return (
    <div>
        <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" onClick={addStudent}>Add Student</button>
        <h1 className="text-3xl font-bold underline">This is table</h1>
        <table className='table-auto'>
            <tr>
                <th>Id</th>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Action</th>
            </tr>
            <tbody>
            {
                data.map((value, key)=>{
                    return(
                        <tr id={key}>
                            <td>{value.id}</td>
                            <td>{value.name}</td>
                            <td>{value.email}</td>
                            <td>{value.phone}</td>
                        </tr>
                    )
                })
            }
            </tbody>
        </table>
    </div>
  )
}

export default Student