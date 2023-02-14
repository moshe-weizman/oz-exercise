import React, { useState, useEffect } from 'react';
import { ExperienceLevel } from "../Models/ExperienceLevel"
import { Col, Row } from 'antd';

let itemsData=[]

  const Candidates = () => {
      const [items, setItems] = useState([]);
      const [languages, setLanguages] = useState([]);
      const [selectedLanguage, setSelectedLanguage] = useState("0");
      const [selectedLevelExperience, setSelectedLevelExperience] = useState("0");

      useEffect(() => {
        fetch(`candidate`).then((results) => {
            return results.json();
            })
            .then(data => {
                setItems(data)
                itemsData=data

            })
    }, [])

      useEffect(() => {
          fetch(`language`).then((results) => {
              return results.json();
          })
              .then(data => {
                  setLanguages(data)
              })
      }, [])

      useEffect(() => {
          filterItems()
      }, [selectedLanguage, selectedLevelExperience])


      const filterItems = () => {

          setItems(
              itemsData.filter(i => ( (selectedLanguage === "0" || i.languages.includes(selectedLanguage)) && 
                  ( selectedLevelExperience === "0" || i.levelExperience == selectedLevelExperience )))
          );
      }

      

    return (
        <main>
            <Row>
            <h2> candidates </h2>
            </Row>
            <Row>
                <Col span={12}>
                    <select onChange={(e) => { setSelectedLanguage(e.target.value) }} defaultValue="0">
                        <option value="0" > all languages</option>
                        {languages.map(language => {
                            return < option key={language.id} value={language.id} > {language.name}</option>
                        })}
                        
                    </select>
                </Col>
                <Col span={12}>
                    <select onChange={(e) => {setSelectedLevelExperience(e.target.value) } } defaultValue="0">
                        <option value="0" > all Experience Level</option>
                        {Object.keys(ExperienceLevel).map((keyLevel) =>
                        { return < option key={keyLevel } value={ExperienceLevel[keyLevel]} > {keyLevel}</option> })}

                    </select>
                </Col>
            </Row > 
            
            {(items !== null && items !== []) ? items.map((item) => (
                <Row key={item.id}>{item.name}</Row>
            )) : <div>no results</div>}
        </main>
        )
}
export default Candidates;