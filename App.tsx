import axios from "axios";
import React, { useState, useEffect } from "react";

interface Store {
  id: number;
  storeName: string;
}

const App: React.FC = () => {
  const [stores, setStores] = useState<Store[]>([]);
  const [id, setId] = useState(0);
  const [storename, setStoreName] = useState("");

  useEffect(() => {
    const fetchData = async () => {
      const result = await axios.get("api/Store");
      setStores(result.data);
    };
    fetchData();
  }, []);
  const handleCreate = async (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    try {
      const { data } = await axios.post(`api/Store/`, { id, storename });
      setStores([...stores, data]);
      setId(0);
      setStoreName("");
    } catch (error) {
      console.log(error);
    }
  };

  const handleDelete = async (id: number) => {
    try {
      await axios.delete(`api/Store/${id}`);
      setStores(stores.filter((store) => store.id !== id));
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <>
      <div>
        <form onSubmit={handleCreate}>
          <input
            id="id"
            type="number"
            value={id}
            onChange={(e) => setId(Number(e.target.value))}
          />
          <input
            id="storename"
            type="text"
            value={storename}
            onChange={(e) => setStoreName(e.target.value)}
          />
          <button type="submit">Create</button>
        </form>
        <ul>
          {stores.map((store) => (
            <li key={store.id}>
              {store.id}({store.storeName})
              <button onClick={() => handleDelete(store.id)}>Delete</button>
            </li>
          ))}
        </ul>
        <table>
          {stores.map((store) => (
            <>
              <tr key={store.id}>
                <td>{store.id}</td>
                <td>{store.storeName}</td>
              </tr>
            </>
          ))}
        </table>
      </div>
    </>
  );
};

export default App;
