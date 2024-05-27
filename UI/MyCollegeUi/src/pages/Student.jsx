import axios from 'axios';
import React, { useEffect, useState, } from 'react'
import { useNavigate } from "react-router-dom";

function Student() {
    const navigate = useNavigate();
    const [data, setData] = useState([]);
    useEffect(() => {
        async function fetchData() {
            const result = await axios.get(`https://localhost:5001/Student/GetStudents`);
            setData(result.data);
        }

        fetchData();

    }, []);

    const updateStudent = (studentData) => {
        navigate('/updateStudentInfo', { state: { studentData } });
    };

    const deleteStudent = async (studentId) => {
        console.log(studentId);
        const res = await axios.delete(`https://localhost:5001/Student/DeleteStudent/${studentId}`);
        setData(res.data);
    };


    


    return (
        <div className='px-10 mt-24 border-10'>
            <div className='relative overflow-x-auto'>
                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead>
                        <tr>
                            <th scope="col" className="px-6 py-3">Id</th>
                            <th scope="col" className="px-6 py-3">FirstName</th>
                            <th scope="col" className="px-6 py-3">MiddleName</th>
                            <th scope="col" className="px-6 py-3">LastName</th>
                            <th scope="col" className="px-6 py-3">Email</th>
                            <th scope="col" className="px-6 py-3">Phone</th>
                            <th scope="col" className="px-6 py-3">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            data.map((value, index) => {
                                return (
                                    <tr className="bg-white border-b dark:bg-gray-800 dark:border-gray-700" key={value.id}>
                                        <td className="px-6 py-4">{value.id}</td>
                                        <td className="px-6 py-4">{value.firstName}</td>
                                        <td className="px-6 py-4">{value.middleName}</td>
                                        <td className="px-6 py-4">{value.lastName}</td>
                                        <td className="px-6 py-4">{value.email}</td>
                                        <td className="px-6 py-4">{value.phone}</td>
                                        <td className="px-6 py-4">
                                            <button type="button" onClick={() => updateStudent(value)} class="focus:outline-none text-white bg-yellow-400 hover:bg-yellow-500 focus:ring-4 focus:ring-yellow-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:focus:ring-yellow-900">Edit</button>
                                        </td>
                                        <td className="px-6 py-4">
                                            <button type="button" onClick={() => deleteStudent(value.id)} class="focus:outline-none text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900">Red</button>
                                        </td>
                                    </tr>
                                )
                            })
                        }
                    </tbody>
                </table>
            </div>
        </div>
    )
}

export default Student