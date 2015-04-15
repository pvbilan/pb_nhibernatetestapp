--
-- PostgreSQL database dump
--

-- Dumped from database version 9.1.7
-- Dumped by pg_dump version 9.2.2
-- Started on 2015-04-15 14:30:56

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

DROP DATABASE "PB_NHibernateTest";
--
-- TOC entry 1907 (class 1262 OID 808037)
-- Name: PB_NHibernateTest; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "PB_NHibernateTest" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'English_United States.1252' LC_CTYPE = 'English_United States.1252';


ALTER DATABASE "PB_NHibernateTest" OWNER TO postgres;

\connect "PB_NHibernateTest"

SET statement_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;

--
-- TOC entry 5 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 1908 (class 0 OID 0)
-- Dependencies: 5
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 171 (class 3079 OID 11639)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 1910 (class 0 OID 0)
-- Dependencies: 171
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 162 (class 1259 OID 808040)
-- Name: company; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE company (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    departmentscount integer NOT NULL,
    description character varying(255)
);


ALTER TABLE public.company OWNER TO postgres;

--
-- TOC entry 161 (class 1259 OID 808038)
-- Name: company_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE company_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.company_id_seq OWNER TO postgres;

--
-- TOC entry 1911 (class 0 OID 0)
-- Dependencies: 161
-- Name: company_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE company_id_seq OWNED BY company.id;


--
-- TOC entry 168 (class 1259 OID 808068)
-- Name: companydepartment; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE companydepartment (
    id integer NOT NULL,
    companyid integer NOT NULL,
    departmentid integer NOT NULL
);


ALTER TABLE public.companydepartment OWNER TO postgres;

--
-- TOC entry 167 (class 1259 OID 808062)
-- Name: companydepartment_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE companydepartment_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.companydepartment_id_seq OWNER TO postgres;

--
-- TOC entry 1912 (class 0 OID 0)
-- Dependencies: 167
-- Name: companydepartment_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE companydepartment_id_seq OWNED BY companydepartment.id;


--
-- TOC entry 164 (class 1259 OID 808046)
-- Name: department; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE department (
    id integer NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE public.department OWNER TO postgres;

--
-- TOC entry 163 (class 1259 OID 808044)
-- Name: department_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE department_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.department_id_seq OWNER TO postgres;

--
-- TOC entry 1913 (class 0 OID 0)
-- Dependencies: 163
-- Name: department_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE department_id_seq OWNED BY department.id;


--
-- TOC entry 170 (class 1259 OID 808115)
-- Name: departmentduty; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE departmentduty (
    id integer NOT NULL,
    departmentid integer NOT NULL,
    dutyid integer NOT NULL
);


ALTER TABLE public.departmentduty OWNER TO postgres;

--
-- TOC entry 169 (class 1259 OID 808109)
-- Name: departmentduty_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE departmentduty_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.departmentduty_id_seq OWNER TO postgres;

--
-- TOC entry 1914 (class 0 OID 0)
-- Dependencies: 169
-- Name: departmentduty_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE departmentduty_id_seq OWNED BY departmentduty.id;


--
-- TOC entry 166 (class 1259 OID 808052)
-- Name: duty; Type: TABLE; Schema: public; Owner: postgres; Tablespace: 
--

CREATE TABLE duty (
    id integer NOT NULL,
    name character varying(255) NOT NULL,
    description character varying(255)
);


ALTER TABLE public.duty OWNER TO postgres;

--
-- TOC entry 165 (class 1259 OID 808050)
-- Name: duty_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE duty_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.duty_id_seq OWNER TO postgres;

--
-- TOC entry 1915 (class 0 OID 0)
-- Dependencies: 165
-- Name: duty_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE duty_id_seq OWNED BY duty.id;


--
-- TOC entry 1874 (class 2604 OID 808043)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY company ALTER COLUMN id SET DEFAULT nextval('company_id_seq'::regclass);


--
-- TOC entry 1877 (class 2604 OID 808071)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY companydepartment ALTER COLUMN id SET DEFAULT nextval('companydepartment_id_seq'::regclass);


--
-- TOC entry 1875 (class 2604 OID 808049)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY department ALTER COLUMN id SET DEFAULT nextval('department_id_seq'::regclass);


--
-- TOC entry 1878 (class 2604 OID 808118)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY departmentduty ALTER COLUMN id SET DEFAULT nextval('departmentduty_id_seq'::regclass);


--
-- TOC entry 1876 (class 2604 OID 808055)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY duty ALTER COLUMN id SET DEFAULT nextval('duty_id_seq'::regclass);


--
-- TOC entry 1894 (class 0 OID 808040)
-- Dependencies: 162
-- Data for Name: company; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO company VALUES (15, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (16, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (17, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (18, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (19, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (20, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (21, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (22, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (24, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (23, 'Test Company', 4, 'Updated company');
INSERT INTO company VALUES (25, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (26, 'Test Company', 4, 'Test Company');
INSERT INTO company VALUES (27, 'Test Company', 4, 'Test Company');


--
-- TOC entry 1916 (class 0 OID 0)
-- Dependencies: 161
-- Name: company_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('company_id_seq', 27, true);


--
-- TOC entry 1900 (class 0 OID 808068)
-- Dependencies: 168
-- Data for Name: companydepartment; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO companydepartment VALUES (10, 15, 1);
INSERT INTO companydepartment VALUES (11, 16, 1);
INSERT INTO companydepartment VALUES (12, 17, 1);
INSERT INTO companydepartment VALUES (13, 18, 1);
INSERT INTO companydepartment VALUES (14, 19, 1);
INSERT INTO companydepartment VALUES (15, 20, 1);
INSERT INTO companydepartment VALUES (16, 21, 1);
INSERT INTO companydepartment VALUES (17, 22, 1);
INSERT INTO companydepartment VALUES (21, 24, 1);
INSERT INTO companydepartment VALUES (22, 24, 2);
INSERT INTO companydepartment VALUES (23, 24, 4);
INSERT INTO companydepartment VALUES (29, 23, 1);
INSERT INTO companydepartment VALUES (27, 23, 2);
INSERT INTO companydepartment VALUES (28, 23, 1);
INSERT INTO companydepartment VALUES (30, 25, 1);
INSERT INTO companydepartment VALUES (31, 25, 2);
INSERT INTO companydepartment VALUES (32, 25, 4);
INSERT INTO companydepartment VALUES (33, 26, 1);
INSERT INTO companydepartment VALUES (34, 26, 2);
INSERT INTO companydepartment VALUES (35, 26, 4);
INSERT INTO companydepartment VALUES (36, 27, 1);
INSERT INTO companydepartment VALUES (37, 27, 2);
INSERT INTO companydepartment VALUES (38, 27, 4);


--
-- TOC entry 1917 (class 0 OID 0)
-- Dependencies: 167
-- Name: companydepartment_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('companydepartment_id_seq', 38, true);


--
-- TOC entry 1896 (class 0 OID 808046)
-- Dependencies: 164
-- Data for Name: department; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO department VALUES (1, '.NET Department');
INSERT INTO department VALUES (2, 'PHP Department');
INSERT INTO department VALUES (3, 'Sales Department');
INSERT INTO department VALUES (4, 'Java Department');
INSERT INTO department VALUES (5, 'iOS Department');
INSERT INTO department VALUES (11, 'TestDeparment');
INSERT INTO department VALUES (12, 'TestDeparment');
INSERT INTO department VALUES (13, 'TestDeparment');
INSERT INTO department VALUES (10, 'TestDepartment 14:16:19');


--
-- TOC entry 1918 (class 0 OID 0)
-- Dependencies: 163
-- Name: department_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('department_id_seq', 13, true);


--
-- TOC entry 1902 (class 0 OID 808115)
-- Dependencies: 170
-- Data for Name: departmentduty; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO departmentduty VALUES (3, 11, 1);
INSERT INTO departmentduty VALUES (5, 1, 3);
INSERT INTO departmentduty VALUES (7, 12, 1);
INSERT INTO departmentduty VALUES (9, 1, 5);
INSERT INTO departmentduty VALUES (78, 10, 11);
INSERT INTO departmentduty VALUES (79, 10, 12);
INSERT INTO departmentduty VALUES (80, 10, 13);
INSERT INTO departmentduty VALUES (81, 10, 14);
INSERT INTO departmentduty VALUES (55, 13, 1);
INSERT INTO departmentduty VALUES (57, 1, 8);


--
-- TOC entry 1919 (class 0 OID 0)
-- Dependencies: 169
-- Name: departmentduty_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('departmentduty_id_seq', 81, true);


--
-- TOC entry 1898 (class 0 OID 808052)
-- Dependencies: 166
-- Data for Name: duty; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO duty VALUES (3, 'TestDuty', NULL);
INSERT INTO duty VALUES (5, 'TestDuty', NULL);
INSERT INTO duty VALUES (8, 'TestDuty', NULL);
INSERT INTO duty VALUES (1, 'Development', 'Development');
INSERT INTO duty VALUES (7, 'TestDuty 13:45:35', 'Inserted');
INSERT INTO duty VALUES (9, 'TestDuty 13:48:22', 'Inserted');
INSERT INTO duty VALUES (10, 'TestDuty 13:49:41', 'Inserted');
INSERT INTO duty VALUES (14, 'TestDuty 14:16:19', 'Inserted');
INSERT INTO duty VALUES (11, 'TestDuty 13:55:05', 'Inserted');
INSERT INTO duty VALUES (12, 'TestDuty 13:55:47', 'Inserted');
INSERT INTO duty VALUES (13, 'TestDuty 14:10:55', 'Inserted');


--
-- TOC entry 1920 (class 0 OID 0)
-- Dependencies: 165
-- Name: duty_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('duty_id_seq', 14, true);


--
-- TOC entry 1886 (class 2606 OID 808079)
-- Name: CompanyDepartment_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY companydepartment
    ADD CONSTRAINT "CompanyDepartment_pkey" PRIMARY KEY (id);


--
-- TOC entry 1880 (class 2606 OID 808075)
-- Name: Company_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY company
    ADD CONSTRAINT "Company_pkey" PRIMARY KEY (id);


--
-- TOC entry 1888 (class 2606 OID 808122)
-- Name: DepartmentDuty_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY departmentduty
    ADD CONSTRAINT "DepartmentDuty_pkey" PRIMARY KEY (id);


--
-- TOC entry 1882 (class 2606 OID 808077)
-- Name: Department_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY department
    ADD CONSTRAINT "Department_pkey" PRIMARY KEY (id);


--
-- TOC entry 1884 (class 2606 OID 808134)
-- Name: Duty_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres; Tablespace: 
--

ALTER TABLE ONLY duty
    ADD CONSTRAINT "Duty_pkey" PRIMARY KEY (id);


--
-- TOC entry 1889 (class 2606 OID 808377)
-- Name: fk_companyid_company_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY companydepartment
    ADD CONSTRAINT fk_companyid_company_id FOREIGN KEY (companyid) REFERENCES company(id);


--
-- TOC entry 1891 (class 2606 OID 808367)
-- Name: fk_departmentid_department_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY departmentduty
    ADD CONSTRAINT fk_departmentid_department_id FOREIGN KEY (departmentid) REFERENCES department(id);


--
-- TOC entry 1890 (class 2606 OID 808382)
-- Name: fk_departmentid_department_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY companydepartment
    ADD CONSTRAINT fk_departmentid_department_id FOREIGN KEY (departmentid) REFERENCES department(id);


--
-- TOC entry 1892 (class 2606 OID 808372)
-- Name: fk_dutyid_duty_id; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY departmentduty
    ADD CONSTRAINT fk_dutyid_duty_id FOREIGN KEY (dutyid) REFERENCES duty(id);


--
-- TOC entry 1909 (class 0 OID 0)
-- Dependencies: 5
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2015-04-15 14:30:57

--
-- PostgreSQL database dump complete
--

